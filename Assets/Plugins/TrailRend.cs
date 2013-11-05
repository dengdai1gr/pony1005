using UnityEngine;
using System.Collections;

public class TrailRend : MonoBehaviour {

	public GameObject hand;
	
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Pub.istoolcut)
		{
			if(Input.GetKey("mouse 0"))
				hand.transform.position=Camera.mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,8));
			//print (hand.transform.position.x+"//"+hand.transform.position.y);
		}
	}
}
