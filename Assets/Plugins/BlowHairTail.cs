using UnityEngine;
using System.Collections;

public class BlowHairTail: MonoBehaviour {


	CBezier cbezier;
	ControlHair controlhair;
	public Transform center;
	private Vector2 direction;
	
	public float p1p=0.4f;
	public float p3p=1.5f;
	
	
	public float p1ylow=0.4f;
	public float p3ylow=0.4f;
	
	void Start () {
	
		cbezier=GetComponent<CBezier>();
		controlhair=GetComponent<ControlHair>();
		
	}

//	void Update () {
//	
//	}
	void FixedUpdate()
	{
		if(Pub.istoolblow)
		{
			if(Input.GetKey("mouse 0")){
				
				if(Camera.mainCamera.ScreenToWorldPoint(Input.mousePosition).y<-8){
					
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
					direction=new Vector2(center.position.x-nowp.x, center.position.y-nowp.y);
					direction.x=Mathf.Clamp(direction.x,-1-Random.value*0.5f,1+Random.value*0.05f);
					direction.y=Mathf.Clamp(direction.y,-1-Random.value*0.5f,1+Random.value*0.05f);
					
					if(cbezier.p3ysl<-10)
					{
						cbezier.p1xsl-=direction.x*p1p;
						cbezier.p1ysl+=direction.y*p1p;	
		
						cbezier.p3xsl-=direction.x*p3p;
						cbezier.p3ysl+=direction.y*p3p;	
					}
					else
					{
						cbezier.p1xsl-=direction.x*p1p;
						cbezier.p1ysl+=direction.y*p1p*p1ylow;	
		
						cbezier.p3xsl-=direction.x*p3p;
						cbezier.p3ysl+=direction.y*p3p*p3ylow;	
					}
					controlhair.CheckMaxDis();
				}
			
			}
		}
	}
	
	
	void ReceiveChange()
	{
		p1ylow=0.9f;
		p3ylow=0.9f;
	}
	void ReceiveBack()
	{
		p1ylow=0.4f;
		p3ylow=0.4f;
	}
	
	

	
}





	
	
	
	



