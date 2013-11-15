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
	private float hairlength;
	
	void Start () {
	
		cbezier=GetComponent<CBezier>();
		controlhair=GetComponent<ControlHair>();
	}
	
	void FixedUpdate () {
	
		if(Pub.istoolcut)
		{		
			if(Input.touchCount<1 && !Input.GetKey("mouse 0"))
				return;	
			ToCut();
		}
		
		if(Pub.istoolrazor)
		{		
			if(Input.touchCount<1 && !Input.GetKey("mouse 0"))
				return;
			 ToRazor();
		}	
	}
	
	
	void ToCut()
	{
		
		hits=Physics.SphereCastAll(Camera.main.ScreenPointToRay(Input.mousePosition),0.7f,100,hairlayer.value);
		if(hits.Length>0){
			
			foreach(RaycastHit hit in hits)
			{
	    		startto=hit.textureCoord;
				hairlength=Mathf.Round(startto.x*100)/100.0f;
				if(hairlength>0.975f){}
				else
				{
					if(hairlength<0.22f)
					{
						hairlength=0.22f;
					}
					else
					{		
						hit.collider.gameObject.SendMessage("Rec",hairlength);//cut hair length
						upmesh(hit.collider.gameObject.name);//remove mesh collider
						Cut(hit.collider.gameObject.name,hairlength);
					}
				}	
					
			}
		}
	}	
	
	void ToRazor()
	{
		hits=Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition),100,hairlayer.value);
		if(hits.Length>0){
			
			foreach(RaycastHit hit in hits)
			{//print(hits.Length);	
	    		startto=hit.textureCoord;
				hairlength=Mathf.Round(startto.x*100)/100.0f;
				if(hairlength>0.97f){}
				else
				{
					if(hairlength<0.3f)
					{
						//here set hair material img
						//hit.collider.gameObject.SetActive(false);
					}
					else
					{				
						hit.collider.gameObject.SendMessage("Rec",hairlength);//cut hair length
						upmesh(hit.collider.gameObject.name);
						Cut(hit.collider.gameObject.name,hairlength);
					
					}
				}	
			}	
		}
	}
	
}
	

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