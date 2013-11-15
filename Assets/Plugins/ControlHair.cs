using UnityEngine;
using System.Collections;

public class ControlHair : MonoBehaviour {

	public Camera cam;
	private Vector2 startp;
	private Vector2 preDrag1;
	private float x;
	private float y;
	private RaycastHit hit;
	CBezier mybezier;
	public bool controlp1=false;
	public bool controlp2=false;
	public bool controlp3=false;
	public float hairlength=1.0f;
	public bool isshort=false;//if hair length is too short can't cut
	
	//add cut down hair  fall
	public GameObject hairfallgm;
	AddLineRender addlinerender;
	LineRenderer line;
	public Material hairmat;
	public int lengthOfLineRenderer = 35;
	private int num=0;
	private Vector3[] setp;
	private GameObject hairfall; //fall hair
	
	
	void Start () {
		
		CutHairs.Cut+=SetHairLength;
		mybezier=GetComponent<CBezier>();
		CheckMaxDis();
		////
		setp=mybezier.vec;
	}
	
	void Update () {
			
	}

	void FixedUpdate()
	{
		
		DoIt();
		CheckMaxDis();
		
		if (Input.GetKeyUp ("mouse 0")) 
		{
			controlp1=false;	
			controlp2=false;	
			controlp3=false;
			startp=new Vector2(0,0);
			preDrag1=new Vector2(0,0);
		}
		preDrag1=startp;	
		
	}


	void DoIt() //control point p1p2p3
	{		
		startp=new Vector2( cam.ScreenToWorldPoint(Input.mousePosition).x,cam.ScreenToWorldPoint(Input.mousePosition).y);
		x=0;
		y=0;
		////x=startp.x-preDrag1.x;
		x=(preDrag1.x-startp.x)*1.5f;
		y=(startp.y-preDrag1.y)*1.5f;
		//x=preDrag1.x-startp.x;
		//y=startp.y-preDrag1.y;	
//		print (x+"//"+y);
		if(controlp1)//change point p1.x  p1.y  
		{
			mybezier.p1xsl+=x;
			mybezier.p1ysl+=y;				
			mybezier.p3xsl+=x*0.75f;//0.75
			mybezier.p3ysl+=y*0.75f;
			mybezier.p2xsl+=x*0.5f;//0.5
			mybezier.p2ysl+=y*0.5f;		
		}
		
		if(controlp2)
		{
			mybezier.p2xsl+=x;
			mybezier.p2ysl+=y;	
			mybezier.p3xsl+=x*0.6f;//0.5
			mybezier.p3ysl+=y*0.6f;
			mybezier.p1xsl+=x*0.4f;//0.5
			mybezier.p1ysl+=y*0.4f;
		}
		
		if(controlp3)
		{
			mybezier.p3xsl+=x*0.9f;
			mybezier.p3ysl+=y*0.9f;
			mybezier.p1xsl+=x*0.2f;
			mybezier.p1ysl+=y*0.2f;//0.25
			mybezier.p2xsl+=-x*1;
			mybezier.p2ysl+=-y*1;	
		}	
	}
	
	public void CheckMaxDis()//hair max length 
	{
		Vector2 maxp1v = Vector2.ClampMagnitude(new Vector2(mybezier.p1xsl,mybezier.p1ysl),3*hairlength);//p1  p0
		mybezier.p1xsl= maxp1v.x;
		mybezier.p1ysl= maxp1v.y;
	
		Vector2 maxp2v = Vector2.ClampMagnitude(new Vector2(mybezier.p2xsl+mybezier.p3xsl,mybezier.p2ysl+mybezier.p3ysl),6*hairlength);	///p2  p0
		mybezier.p2xsl=maxp2v.x-mybezier.p3xsl;
		mybezier.p2ysl=maxp2v.y-mybezier.p3ysl;
		mybezier.p2xsl=Mathf.Clamp(mybezier.p2xsl,-3*hairlength,3*hairlength);//p2  p3
		mybezier.p2ysl=Mathf.Clamp(mybezier.p2ysl,-3*hairlength,3*hairlength);	
			
		Vector2 maxp3v =Vector2.ClampMagnitude(new Vector2(mybezier.p3xsl,mybezier.p3ysl),9*hairlength);		//p3  p0
		mybezier.p3xsl= maxp3v.x;
		mybezier.p3ysl= maxp3v.y;
		
		CheckDis();//finger and hair center distance if far can't control
		TooShort();
	}
	
	public void HitP1()
	{
		if(!controlp1)
		{
			controlp1=true;	
			controlp2=false;	
			controlp3=false;	
		}
	}
	public void HitP2()
	{
		if(!controlp2)
		{
			controlp1=false;	
			controlp2=true;	
			controlp3=false;	
		}
	}
	public void HitP3()
	{
		if(!controlp3)
		{
			controlp1=false;	
			controlp2=false;	
			controlp3=true;	
		}
	}
	
	void CheckDis()
	{
		float dis = Vector2.Distance(startp,new Vector2(mybezier.cubes[6].transform.position.x,mybezier.cubes[6].transform.position.y));
		//print(dis);
		if(dis>hairlength*4f)//hairlength 1 = 1.7 dis
			TooFar();
	}
	public void TooFar()
	{
		controlp1=false;	
		controlp2=false;	
		controlp3=false;	
	}
	
	void TooShort(){//short
		if(hairlength<0.22f)
		{
			//Destroy(gameObject.GetComponent("MeshCollider"));
			isshort=false;
		}
		else{
			isshort=true;
		}
	}
	
	void SetHairLength(string myname, float numb)//delegate cut hair
	{
		if(isshort){
			if(myname==gameObject.name){
				hairlength*=numb;
				CheckMaxDis();
				Invoke("AddM",0.2f);
			}
		}
	}
	
	void AddM()// add meshcollider
	{
		if(!gameObject.GetComponent<MeshCollider>())
		{	
			gameObject.AddComponent<MeshCollider>();	
			//gameObject.SetActiveRecursively(false);
			//gameObject.SetActive(true);	
		}
	}
	
	
	void HairLengthAdd()
	{
		if(hairlength<2.6f){
			
			hairlength+=0.03f;
			mybezier.p1xsl=mybezier.p1xsl*1.05f;
			mybezier.p1ysl=mybezier.p1ysl*1.05f;
			mybezier.p3xsl=mybezier.p3xsl*1.1f;
			mybezier.p3ysl=mybezier.p3ysl*1.1f;
		}		
		CheckMaxDis();
	}
	
	

	void CutDownHair()//cut hair fall
	{
		hairfall=Instantiate(hairfallgm,gameObject.transform.position ,gameObject.transform.rotation) as GameObject;
		hairfall.transform.parent=gameObject.transform.parent.parent;
		addlinerender=hairfall.GetComponent<AddLineRender>();
		if(!hairfall.GetComponent<LineRenderer>())
		{	
			line =hairfall.AddComponent<LineRenderer>();
		}
		line.SetWidth(0.5f, 0.7f);
		line.useWorldSpace = false;
		line.SetVertexCount(lengthOfLineRenderer);
		line.material=hairmat;
		for(int i=0; i<lengthOfLineRenderer; i++)
		{
			if(i<num)
			{
				setp[i]=setp[num];
			}
			else
			{
				//setp[i]=cbezier.vec[i];
			}
			line.SetPosition(i, setp[i]);
		}
		Destroy(hairfall,2f);	
	}
	
	
	void Rec(float n)//cut hair little n~0.999  
	{
		num=Mathf.RoundToInt(n*35);
		CutDownHair();
		float movetime=1.5f+n*0.6f;
		Move(movetime);
		
	}
	
	void Move(float times)
	{
		print (times);
		Hashtable htb=new Hashtable ();
		htb.Add("ease", LeanTweenType.easeInOutBack);//easeInOutBack    easeInCirc
		LeanTween.moveLocal(hairfall,new Vector3(8.1f,-15f,9.6f),times,htb);//-30,2.98f,15.92f
	}
	
	
	
	void OnDestroy()
	{
		CutHairs.Cut-=SetHairLength;
	}
}



