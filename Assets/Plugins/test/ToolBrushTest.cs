using UnityEngine;
using System.Collections;

public class ToolBrushTest: MonoBehaviour {

	//test input
	
	float swipeSpeed = 0.001F;
	float inputX;
	float inputY;

	
	
	void FixedUpdate() {
		
 	 if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
     
		Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;						 
    	inputX += touchDeltaPosition.x * swipeSpeed;
    	inputY += touchDeltaPosition.y * swipeSpeed;
    	print("X, Y: " + touchDeltaPosition.x	+ ", " + touchDeltaPosition.y);
  }
	}
	
	
	

	
	
}
