using UnityEngine;
using System.Collections;

public class AddLineRender : MonoBehaviour {

	// Use this for initialization
	LineRenderer lineRenderer;
	public Material hairmat;
	public int lengthOfLineRenderer = 20;
	public string gamename="p91";
	CBezier cbezier;
	private Vector3[] setp;
	private int num=0;

	void Start () {
	
		
	}
	
	void Update () {
	
	}
	
	
	void ToAdd()
	{
		
		GameObject	parentgm =GameObject.Find(gamename);
		cbezier=parentgm.GetComponent<CBezier>();
		setp=cbezier.vec;

		gameObject.transform.position=parentgm.transform.position;
		gameObject.transform.rotation=parentgm.transform.rotation;
		
		if(!gameObject.GetComponent<LineRenderer>())
		{	
			lineRenderer =gameObject.AddComponent<LineRenderer>();
		}
		lineRenderer.SetWidth(0.7f, 0.7f);
		lineRenderer.useWorldSpace = false;
		lineRenderer.SetVertexCount(lengthOfLineRenderer);
		lineRenderer.material=hairmat;
		for(int i=0; i<lengthOfLineRenderer; i++)
		{
			if(i<num)
			{
				setp[i]=setp[num];
			}
			else
			{
				//setp[i]=cbezier.vec[i];
			}
			lineRenderer.SetPosition(i, setp[i]);
		}
		
		
		
//		//test instantice gameonject and add linerenderer 
//		GameObject newgm= Instantiate(emptygm,gameObject.transform.position,gameObject.transform.rotation) as GameObject;
//		newgm.transform.localScale=new Vector3(0.6f,0.6f,0.6f);
//		newgm.transform.parent=gameObject.transform.parent;
//		LineRenderer lineR=newgm.AddComponent<LineRenderer>();
//		lineR.SetWidth(0.5f, 0.7f);
//		lineR.useWorldSpace = false;
//		lineR.SetVertexCount(lengthOfLineRenderer-num);
//		lineR.material=hairmat;
//		for(int i=0; i<lengthOfLineRenderer-num; i++)
//		{
//			emptyp[i]=setp[num+i];
//			lineR.SetPosition(i, emptyp[i]);
//		}

		
		
	}
	

	
	void Rec(float n)
	{
		num=Mathf.RoundToInt(n*lengthOfLineRenderer);
		print (num);
		ToAdd();
		Move();
	}
	
	void Move()
	{
		Hashtable htb=new Hashtable ();
		htb.Add("ease", LeanTweenType.easeInCirc);
		LeanTween.moveLocal(gameObject,new Vector3(-30,2.98f,15.92f),1.5f,htb);//-25,2.98f,13.3f
	}
}
