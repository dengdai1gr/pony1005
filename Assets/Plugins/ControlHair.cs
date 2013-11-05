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
	void Start () {
		
		CutHairs.Cut+=SetHairLength;
		mybezier=GetComponent<CBezier>();
		CheckMaxDis();
	}
	
	void Update () {
			
		preDrag1=startp;	
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
		
	}


	void DoIt() //control point p1p2p3
	{		
		startp=new Vector2( cam.ScreenToWorldPoint(Input.mousePosition).x,cam.ScreenToWorldPoint(Input.mousePosition).y);
		x=0;
		y=0;
		////x=startp.x-preDrag1.x;
		x=(preDrag1.x-startp.x)*1.4f;
		y=(startp.y-preDrag1.y)*1.4f;
//		print (x+"//"+y);
	
		if(controlp1)//change point p1.x  p1.y  
		{
			mybezier.p1xsl+=x;
			mybezier.p1ysl+=y;
					
			mybezier.p3xsl+=x*0.5f;//0.75
			mybezier.p3ysl+=y*0.5f;
			
			mybezier.p2xsl+=x*0.25f;//0.5
			mybezier.p2ysl+=y*0.25f;		
		}
		
		if(controlp2)
		{
			mybezier.p2xsl+=x;
			mybezier.p2ysl+=y;	
		
			mybezier.p3xsl+=x*0.25f;//0.5
			mybezier.p3ysl+=y*0.25f;
	
			mybezier.p1xsl+=x*0.25f;//0.5
			mybezier.p1ysl+=y*0.25f;
		}
		
		if(controlp3)
		{
			mybezier.p3xsl+=x;
			mybezier.p3ysl+=y;
	
			mybezier.p1xsl+=x*0.15f;
			mybezier.p1ysl+=y*0.15f;//0.25
	
			mybezier.p2xsl+=-x*1.15f;
			mybezier.p2ysl+=-y*1.15f;	
		}
	
	}
	
	public void CheckMaxDis()// max length 
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
		
		
		
		//test finger and center distance
		CheckDis();
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
			//print ("short");
			Destroy(gameObject.GetComponent("MeshCollider"));
			//gameObject.SetActiveRecursively(true);
			isshort=false;
		}
		else{
			isshort=true;
		}
	}
	
	
	//delegate cut hair
	void SetHairLength(string myname, float numb)
	{
		if(isshort){
			if(myname==gameObject.name){
				hairlength*=numb;
				CheckMaxDis();
				Invoke("AddM",0.05f);
			}
		}
	}
	
	// add meshcollider
	void AddM()
	{
		if(!gameObject.GetComponent<MeshCollider>())
		{	
			gameObject.AddComponent<MeshCollider>();	
			gameObject.SetActiveRecursively(false);
			gameObject.SetActive(true);	
		}
	}
	
	
	
	void OnDestroy()
	{
		CutHairs.Cut-=SetHairLength;
	}
}



