using UnityEngine;
using System.Collections;

public class BlowHairTail: MonoBehaviour {


	CBezier cbezier;
	ControlTail controltail;
	public Transform center;
	private Vector2 direction;
	private Vector2 direction2;
	private float distance;
	private float randoms;
	
	void Start () {
	
		cbezier=GetComponent<CBezier>();
		controltail=GetComponent<ControlTail>();
		
	}

	void Update()
	{
		if(Pub.istoolblow)
		{
			
			if(Input.GetKey("mouse 0")){
				
				if(Camera.mainCamera.ScreenToWorldPoint(Input.mousePosition).y<-8.5f){}
				else{
				
					float p1force;
				
					Vector2 mousep=Camera.main.ScreenToWorldPoint(Input.mousePosition);
					distance=Vector2.Distance(mousep,new Vector2(center.position.x,center.position.y));
					if(distance<4f)
						distance=4f;
					
					direction=new Vector2(center.position.x-mousep.x, center.position.y-mousep.y);
					direction2=direction;
					
					direction.x=direction.x*(2.5f/distance);
					direction.y=direction.y*(2.5f/distance);  //max is 2.5
					direction2.x=direction2.x*(2.5f/distance);
					direction2.y=direction2.y*(2.5f/distance);
					
					//randoms=0.4f*(0.5f-Random.value);
					
					
					direction.y= direction.y- 0.15f*distance  +  (0.01f*distance+0.5f +randoms)*Mathf.Sin(Time.time* (240/distance +randoms*10) );
					direction.x= direction.x+                    (0.01f*distance+0.5f +randoms)*Mathf.Sin(Time.time* (240/distance +randoms*10) );
				
					
					direction2.y= direction2.y- 0.15f*distance  +  (0.01f*distance+0.5f +randoms)*Mathf.Sin(180+Time.time* (200/distance +randoms*10) );
					direction2.x= direction2.x+                    (0.01f*distance+0.5f +randoms)*Mathf.Sin(180+Time.time* (200/distance +randoms*10) );
					
	
					cbezier.p3xsl-=direction.x;
					cbezier.p3ysl+=direction.y;	
	
					cbezier.p2xsl-=direction2.x;
					cbezier.p2ysl+=direction2.y;	
				
			
		
					
				//direction.x=Mathf.Clamp(direction.x,-25f,25);
				//direction.y=Mathf.Clamp(direction.y,-25f,25);
				
				
				controltail.CheckMaxDis();
				}
			}
			if(Input.GetKeyUp("mouse 0")){
				
			}
			if(Input.GetKeyDown("mouse 0")){
				randoms=0.4f*(0.5f-Random.value);
			}
		}
	}

	
	
	
	
	
	
	
	
	
	
	
	
//	void OnGUI()
//	{
//		GUI.Label(new Rect(0,300,200,30),"Dis"+distance);
//		GUI.Label(new Rect(0,340,200,30),"x:"+direction.x);
//		GUI.Label(new Rect(0,380,200,30),"y:"+direction.y);
//	}
	
	

}





//cbezier.p1xsl-=direction.x;
//cbezier.p1ysl+=direction.y;	