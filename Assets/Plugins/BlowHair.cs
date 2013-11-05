using UnityEngine;
using System.Collections;

public class BlowHair: MonoBehaviour {


	CBezier cbezier;
	ControlHair controlhair;
	public Transform center;
	public Vector2 nowposition;
	public Vector2 direction;
	
	void Start () {
	
		cbezier=GetComponent<CBezier>();
		controlhair=GetComponent<ControlHair>();
		
	}

//	void Update () {
//	
//	}
	void Update()
	{
		if(Pub.istoolblow)
		{
			if(Input.GetKey("mouse 0")){
				
				if(Camera.mainCamera.ScreenToWorldPoint(Input.mousePosition).y<-8){
					
				}
				else{
				
					float p1force;
					p1force=Random.value*0.5f;
					cbezier.p1xsl+=p1force;
					cbezier.p1ysl+=p1force;
					p1force=Random.value*0.6f;
					cbezier.p3xsl+=p1force;
					cbezier.p3ysl+=p1force;
				
					Vector2 nowp=Camera.main.ScreenToWorldPoint(Input.mousePosition);
					direction=new Vector2(center.position.x-nowp.x, center.position.y-nowp.y);
					direction.x=Mathf.Clamp(direction.x,-1-Random.value*0.5f,1+Random.value*0.5f);
					direction.y=Mathf.Clamp(direction.y,-1-Random.value*0.5f,1+Random.value*0.5f);
					
					cbezier.p1xsl-=direction.x*0.5f;
					cbezier.p1ysl+=direction.y*0.5f;	
		
					cbezier.p3xsl-=direction.x*1.5f;
					cbezier.p3ysl+=direction.y*1.5f;	
					controlhair.CheckMaxDis();
				}
			
			}
		}
	}
	
	

	
}





	
	
	
	



