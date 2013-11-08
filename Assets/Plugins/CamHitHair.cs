using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CamHitHair : MonoBehaviour {


	public LayerMask hairlayer;
	private RaycastHit[] hits;
	
	//test array
	//private ArrayList arr;
	//public List<Vector2> list; 
	
	void Start () {	
		
	}

	void Update () {
	
		if(Pub.istoolbrush){
			
			if(Input.touchCount<1 && !Input.GetKey("mouse 0"))
				return;	
			
			//hits=Physics.RaycastAll(gameObject.camera.ScreenPointToRay(Input.mousePosition),100,hairlayer.value);
			hits=Physics.SphereCastAll(gameObject.camera.ScreenPointToRay(Input.mousePosition),0.5f,100,hairlayer.value);
			if(hits.Length>0){
				
				foreach(RaycastHit hit in hits)
				{//print(hits.Length);
					
					if(hit.collider.name=="cp1")
					{
						hit.collider.gameObject.transform.parent.SendMessage("HitP1",SendMessageOptions.RequireReceiver);
					}
					else if(hit.collider.name=="cp2")
					{
						hit.collider.gameObject.transform.parent.SendMessage("HitP2",SendMessageOptions.RequireReceiver);
					}
					else if(hit.collider.name=="cp3"|| hit.collider.name=="cp4")
					{
						hit.collider.gameObject.transform.parent.SendMessage("HitP3",SendMessageOptions.RequireReceiver);
					}
				}
			}			
		}
	}
}
