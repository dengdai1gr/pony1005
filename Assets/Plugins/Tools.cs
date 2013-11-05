using UnityEngine;
using System.Collections;

public class Tools : MonoBehaviour {

	
	public delegate void EventHandler(int num);
	static public event EventHandler HitTool;
	private RaycastHit hit;
	public LayerMask toollayer;
	
	public Texture2D[] img;
	public Texture2D[] imgl;
	public GameObject [] toolsgameobject;
	//public Mesh meshToCollider;
	
	private GameObject[] gm;
	
	void Awake()
	{
		gm= GameObject.FindGameObjectsWithTag("hairtag");
	}
	
	void Start () {
	
		HitTool(2);
		ChangeImg(2);
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown("mouse 0")){
			
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,toollayer.value)){
				

				if(hit.collider.name=="scissor"){					
					HitTool(1);	
					ChangeImg(1);
					Addd();
					RemoveControlCube();
				}
				if(hit.collider.name=="brush"){
					HitTool(2);
					ChangeImg(2);
					Removee();
					AddControlCube();
				}
				if(hit.collider.name=="razor"){
					HitTool(3);
					ChangeImg(3);
					Removee();
					RemoveControlCube();
				}
				if(hit.collider.name=="blow"){
					HitTool(4);
					ChangeImg(4);
					Removee();
					RemoveControlCube();
				}
			}
		}
		
	}
	void ChangeImg(int num)
	{
		switch(num)
		{
		case 0:
			toolsgameobject[1].renderer.material.mainTexture=img[1];
			toolsgameobject[2].renderer.material.mainTexture=img[2];
			toolsgameobject[3].renderer.material.mainTexture=img[3];
			toolsgameobject[4].renderer.material.mainTexture=img[4];
			break;
		case 1:
			toolsgameobject[1].renderer.material.mainTexture=imgl[1];
			toolsgameobject[2].renderer.material.mainTexture=img[2];
			toolsgameobject[3].renderer.material.mainTexture=img[3];
			toolsgameobject[4].renderer.material.mainTexture=img[4];
			break;
			
		case 2:
			toolsgameobject[1].renderer.material.mainTexture=img[1];
			toolsgameobject[2].renderer.material.mainTexture=imgl[2];
			toolsgameobject[3].renderer.material.mainTexture=img[3];
			toolsgameobject[4].renderer.material.mainTexture=img[4];
			break;
			 
		case 3:
			toolsgameobject[1].renderer.material.mainTexture=img[1];
			toolsgameobject[2].renderer.material.mainTexture=img[2];
			toolsgameobject[3].renderer.material.mainTexture=imgl[3];
			toolsgameobject[4].renderer.material.mainTexture=img[4];
			break;
			
		case 4:
			toolsgameobject[1].renderer.material.mainTexture=img[1];
			toolsgameobject[2].renderer.material.mainTexture=img[2];
			toolsgameobject[3].renderer.material.mainTexture=img[3];
			toolsgameobject[4].renderer.material.mainTexture=imgl[4];
			break;
			
		}
	}
	
	void Addd() //when cut  add mesh
	{
		foreach(GameObject hair in gm)
		{
			if(!hair.GetComponent<MeshCollider>())
				hair.AddComponent<MeshCollider>();
		}
	}
			
	void Removee()//remove meshcollider
	{
		//GameObject[] gm= GameObject.FindGameObjectsWithTag("hairtag");
		foreach(GameObject hair in gm)
		{
			Destroy(hair.GetComponent<MeshCollider>());
			//hair.SetActiveRecursively(true);
		}
	}
	
	void RemoveControlCube()
	{
		foreach(GameObject hair in gm)
		{
			hair.SetActiveRecursively(false);
			hair.SetActive(true);
		}
	}
	void AddControlCube()
	{
		foreach(GameObject hair in gm)
		{
			hair.SetActiveRecursively(true);
		}
	}
	
}
