using UnityEngine;
using System.Collections;

public class GrowUp : MonoBehaviour {

	private GameObject[] gms;
	private Vector2 nowp;
	private float dis;
	void Start () {
	
		gms=GameObject.FindGameObjectsWithTag("hairtag");
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Pub.ispilatory)
		{
			if(Input.touchCount<1 && !Input.GetKey("mouse 0"))
				return;
			AddLength ();
		}
	}
	
	void AddLength()//add hairlength near finger
	{
		foreach(GameObject g in gms)
		{
			nowp=Camera.main.ScreenToWorldPoint(Input.mousePosition);
			dis=Vector2.Distance(nowp,new Vector2(g.transform.position.x,g.transform.position.y));
			if(dis<1.7f)
			{
				g.SendMessage("HairLengthAdd");
			}
		}
	}
}
