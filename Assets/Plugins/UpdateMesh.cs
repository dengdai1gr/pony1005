using UnityEngine;
using System.Collections;

public class UpdateMesh : MonoBehaviour {

	
	void Start () {
	
		CutHairs.upmesh+=UpMesh;
	}

	void Update () {

	}
	
	void UpMesh(string gamename)//remove mesh when hit
	{
		GameObject gm= GameObject.Find(gamename);
		if(gm && gm.GetComponent<MeshCollider>())
		{
			Destroy(gm.GetComponent<MeshCollider>());
		}
	}

	void OnDestroy()
	{
		CutHairs.upmesh-=UpMesh;
	}
}




//	void Addd()
//	{
//		GameObject gm= GameObject.Find(addname);
//		if(!gm.GetComponent<MeshCollider>())
//		{	
//			gm.AddComponent<MeshCollider>();
//			
//			gm.SetActiveRecursively(false);
//			gm.SetActive(true);	
//		}
//	}
//	
//	void Removee(string srem)
//	{
//		GameObject gm= GameObject.Find(srem);
//		Destroy(gm.GetComponent("MeshCollider"));
//	}
//	
//	void UpMesh(string gamename)
//	{
//		print (gamename);
//		Removee(gamename);
//		addname=gamename;
//		Invoke("Addd",0.05f);	
//	}

//	void Addd()
//	{
//		GameObject[] gm= GameObject.FindGameObjectsWithTag("hairtag");
//		foreach(GameObject hair in gm)
//		{
//			hair.AddComponent("MeshCollider");
//			hair.SetActiveRecursively(false);
//			hair.SetActive(true);
//		}
//	}
//	void Removee()
//	{
//		GameObject[] gm= GameObject.FindGameObjectsWithTag("hairtag");
//		foreach(GameObject hair in gm)
//		{
//			Destroy(hair.GetComponent("MeshCollider"));
//			hair.SetActiveRecursively(true);
//		}
//	}
//gm.GetComponent<MeshCollider>().sharedMesh=meshToCollider;