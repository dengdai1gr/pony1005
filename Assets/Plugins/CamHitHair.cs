using UnityEngine;
using System.Collections;

public class CamHitHair : MonoBehaviour {


	public LayerMask hairlayer;
	public RaycastHit[] hits;
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if(Pub.istoolbrush){
		if (Input.GetKey ("mouse 0")) {
		
			hits=Physics.RaycastAll(gameObject.camera.ScreenPointToRay(Input.mousePosition),100,hairlayer.value);

			if(hits.Length>0){
				
				foreach(RaycastHit hit in hits)
				{
					//print(hits.Length);
					if(hit.collider.name=="cp1")
					{
						hit.collider.gameObject.transform.parent.SendMessage("HitP1",SendMessageOptions.RequireReceiver);
					}
					if(hit.collider.name=="cp2")
					{
						hit.collider.gameObject.transform.parent.SendMessage("HitP2",SendMessageOptions.RequireReceiver);
					}
					if(hit.collider.name=="cp3"|| hit.collider.name=="cp4")
					{
						hit.collider.gameObject.transform.parent.SendMessage("HitP3",SendMessageOptions.RequireReceiver);
					}
				}
			}	
		}
	}
}
}