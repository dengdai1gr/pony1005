using UnityEngine;
using System.Collections;

public class ToolBrushTest: MonoBehaviour {

	public Texture2D img;
	public Texture2D imgl;
	
	
	
	
	//test input
	
	float swipeSpeed = 0.001F;
	float inputX;
	float inputY;
	
	
	void Start () {
	
		//Tools.HitTool+=IsOther;
	}
	
	void Update () {
	
//		if(Input.GetKeyDown("mouse 0")){
//			
//		if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit))
//		{
//			if(hit.collider.name=="blow")
//			{
//				hit.collider.gameObject.renderer.material.mainTexture=imgl;
//			}
//		}
	}
	
	
	
//	void IsOther(int number)
//	{
//		if(number==2){
//			gameObject.renderer.material.mainTexture=imgl;
//		}
//		else{
//			gameObject.renderer.material.mainTexture=img;
//		}
//	}
	
	
	
	void FixedUpdate() {
		
 	 if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
     
		Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;						 
    	inputX += touchDeltaPosition.x * swipeSpeed;
    	inputY += touchDeltaPosition.y * swipeSpeed;
    	print("X, Y: " + touchDeltaPosition.x	+ ", " + touchDeltaPosition.y);
  }
	}
	
	
	

	
	
}
