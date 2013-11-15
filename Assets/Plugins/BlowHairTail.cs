using UnityEngine;
using System.Collections;

public class BlowHairTail: MonoBehaviour {


	CBezier cbezier;
	ControlTail controltail;
	//public Transform center;
	private Vector2 direction;
	
	public float p1p=0.4f;
	public float p3p=1.5f;
	
	
	public float p1ylow=0.4f;
	public float p3ylow=0.4f;
	
	void Start () {
	
		cbezier=GetComponent<CBezier>();
		controltail=GetComponent<ControlTail>();
		
	}

//	void Update () {
//	
//	}
	void Update()
	{
		if(Pub.istoolblow)
		{
			if(Input.GetKey("mouse 0")){
				
				if(Camera.mainCamera.ScreenToWorldPoint(Input.mousePosition).y<-8.2f){
					
				}
				else{
				
					float p1force;
					p1force=Random.value*p1p;//0.5
					cbezier.p1xsl+=p1force;
					cbezier.p1ysl+=p1force;
					
					p1force=Random.value*p1p;//0.6
					cbezier.p3xsl+=p1force;
					cbezier.p3ysl+=p1force;
				
					Vector2 nowp=Camera.main.ScreenToWorldPoint(Input.mousePosition);
					//direction=new Vector2(center.position.x-nowp.x, center.position.y-nowp.y);
					direction=new Vector2(gameObject.transform.position.x-nowp.x,gameObject.transform.position.y-nowp.y);
					direction.x=Mathf.Clamp(direction.x*0.1f,-1-Random.value*0.5f,1+Random.value*0.05f);
					direction.y=Mathf.Clamp(direction.y*0.1f,-1-Random.value*0.5f,1+Random.value*0.05f);
					
					print(direction.x+"//"+direction.y);
					
//					if(cbezier.p3ysl<-10)
//					{
						cbezier.p1xsl-=direction.x*p1p;
						cbezier.p1ysl+=direction.y*p1p;	
		
						cbezier.p3xsl-=direction.x*p3p;
						cbezier.p3ysl+=direction.y*p3p;	
//					}
//					else
//					{
//						cbezier.p1xsl-=direction.x*p1p;
//					    cbezier.p1ysl+=direction.y*p1p*p1ylow;	
//		
//						cbezier.p3xsl-=direction.x*p3p;
//						cbezier.p3ysl+=direction.y*p3p*p3ylow;	
//					}
					controltail.CheckMaxDis();
				}
			
		
			if(Input.GetKeyUp("mouse 0"))
			{
				if(controltail.hairlength>2)
				{
					//can return
					//ComeBack();
				}
				else
				{
			
				}
			}
		}
		}
	}
	

	void ComeBack()
	{
		Hashtable htb= new Hashtable ();
		htb.Add("ease",LeanTweenType.easeOutQuint);
		LeanTween.value(gameObject,Recb,cbezier.p3ysl,-12,2f,htb);			
			
		controltail.CheckMaxDis();
	}
	void Recb(float a)
	{
		cbezier.p3ysl=a;
	}
	
	void OnGUI()
	{
//		if(GUI.Button(new  Rect(0,300,50,50),"enter"))
//		{
//			ComeBack();
//		}
	}
	
	
	
	void ReceiveChange()
	{
		//p1ylow=0.9f;
		//p3ylow=0.9f;
	}
	void ReceiveBack()
	{
		//p1ylow=0.4f;
		//p3ylow=0.4f;
	}

}





	
	
	
	



