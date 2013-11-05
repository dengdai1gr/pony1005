using UnityEngine;
using System.Collections;

public class CutHairs : MonoBehaviour {
	
	public delegate void EventCutHandler(string hairname, float num);//cut hair length * hit.length
	static public event EventCutHandler Cut;
	
	public delegate void EventMeshHandle(string s);
	static public event EventMeshHandle upmesh;
	
	CBezier cbezier;
	ControlHair controlhair;
	public LayerMask hairlayer;
	private RaycastHit hit;
	private RaycastHit[] hits;
	
	private Vector2 startto;
	public float hairlength;
	
	void Start () {
	
		cbezier=GetComponent<CBezier>();
		controlhair=GetComponent<ControlHair>();
	}
	
	void FixedUpdate () {
	
		if(Pub.istoolcut)
		{		
//			if (Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition),out hit,hairlayer.value))
//	   	 	{	  
//	    		//if(hit.collider.name=="p1"){
//				if(hit.collider.name!="blow" &&hit.collider.name!="brush" && hit.collider.name!="razor" && hit.collider.name!="scissor"  ){
//	    			startto=hit.textureCoord;
//				//	print(hit.collider.name+"/////"+startto.x+"aaaaa"+startto.y+"cut:"+hairlength);
//					//CutHair();
//					hairlength=Mathf.Round(startto.x*100)/100.0f;
//					
//					if(hairlength<0.22f)
//					{
//						hairlength=0.22f;
//					}
//					Cut(hit.collider.gameObject.name,hairlength);
//					upmesh();
//	    		}
//			}
				
							
				
			hits=Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition),100,hairlayer.value);
			if(hits.Length>0){
			
				foreach(RaycastHit hit in hits)
				{
					//print(hits.Length);
					if(hit.collider.name!="blow" &&hit.collider.name!="brush" && hit.collider.name!="razor" && hit.collider.name!="scissor"  ){
	    			startto=hit.textureCoord;
					hairlength=Mathf.Round(startto.x*100)/100.0f;
					
					upmesh(hit.collider.gameObject.name);
					if(hairlength<0.22f)
					{
						hairlength=0.22f;
					}
					Cut(hit.collider.gameObject.name,hairlength);
					
	    		}
			}

				
				
						
						
						
						
				
				
//				if(hit.collider.name=="p2"){
//					
//	    			startto=hit.textureCoord;
//					//print(hit.collider.name+"/////"+startto.x+"aaaaa"+startto.y);
//					hairlength=Mathf.Round(startto.x*100)/100.0f;
//					Cut(hit.collider.gameObject.name,hairlength);
//					if(hairlength<0.22f)
//					{
//						hairlength=0.22f;
//					}
//					upmesh();
//	    		}
	    	
		}
	}
	
	
//	void CutHair()
//	{
//		hairlength=Mathf.Round(startto.x*100)/100.0f;
//		print (hairlength);
//		Cut(hairlength);
//		upmesh();
//	}	


	}
}
	

