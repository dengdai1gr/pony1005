using UnityEngine;
using System.Collections;

public class TrailRend : MonoBehaviour {

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Pub.istoolcut)
		{
			if(Input.touchCount<1 && !Input.GetKey("mouse 0"))
				return;	
			gameObject.transform.position=Camera.mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,8));
		}
	}
}
