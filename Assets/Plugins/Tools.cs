using UnityEngine;
using System.Collections;

public class Tools : MonoBehaviour {

	
	public delegate void EventHandler(int num);
	static public event EventHandler HitTool;
	private RaycastHit hit;
	public LayerMask toollayer;
	private GameObject[] gm;
	
	void Awake()
	{
		gm= GameObject.FindGameObjectsWithTag("hairtag");
	}
	
	void Start () {
	
		HitTool(2);
		ChangeImg("brush");
	}
	
	void Update () {
	
		
		if(Input.touchCount<1 && !Input.GetKey("mouse 0"))
				return;
		
		if(Input.GetKeyDown("mouse 0")){
			
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,toollayer.value)){			

				if(hit.collider.name=="scissor"){					
					HitTool(1);	
					ChangeImg("scissor");
					AddMesh();
					RemoveControl();
				}
				if(hit.collider.name=="brush"){
					HitTool(2);
					ChangeImg("brush");
					RemoveMesh();
					AddControl();
				}
				if(hit.collider.name=="razor"){
					HitTool(3);
					ChangeImg("razor");
					AddMesh();
					RemoveControl();
				}
				if(hit.collider.name=="blow"){
					HitTool(4);
					ChangeImg("blow");
					RemoveMesh();
					RemoveControl();
				}
				if(hit.collider.name=="pilatory"){
					HitTool(5);
					ChangeImg("pilatory");
					RemoveMesh();
					RemoveControl();
				}
			}
		}
		
	}
	void ChangeImg(string toolname)//change tools texture
	{
		GameObject[] tools= GameObject.FindGameObjectsWithTag("tooltag");
		foreach(GameObject  toolgm in tools)
		{
			if(toolgm.name!=toolname)
			{
				toolgm.SendMessage("NoSelect");
			}
			else
			{
				toolgm.SendMessage("IsSelect");
			}
		}

	}
	
	void AddMesh() //when cut  add mesh
	{
		foreach(GameObject hair in gm)
		{
			if(!hair.GetComponent<MeshCollider>())
				hair.AddComponent<MeshCollider>();
		}
	}
			
	void RemoveMesh()//remove meshcollider
	{
		foreach(GameObject hair in gm)
		{
			if(hair.GetComponent<MeshCollider>())
				Destroy(hair.GetComponent<MeshCollider>());
		}
	}
	
	void RemoveControl()
	{
		foreach(GameObject hair in gm)
		{
			hair.SetActiveRecursively(false);
			hair.SetActive(true);
		}
	}
	void AddControl()
	{
		foreach(GameObject hair in gm)
		{
			hair.SetActiveRecursively(true);
		}
	}
	
	void PlayAnimation()
	{
		HitTool(0);
		ChangeImg("no");
		RemoveControl();
		RemoveMesh();
	}
	
}
