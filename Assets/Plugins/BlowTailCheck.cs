using UnityEngine;
using System.Collections;

public class BlowTailCheck : MonoBehaviour {

	public Vector2 nowp;
	public Transform center;
	private float dis;
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		if(Pub.istoolblow)
		{
			nowp=Camera.main.ScreenToWorldPoint(Input.mousePosition);
			dis=Vector2.Distance(nowp,new Vector2(center.position.x,center.position.y));
			
			
			
			//print (dis); //1
			
			if(dis<8)//very close
			{
			gameObject.BroadcastMessage("ReceiveChange");
			}
			else
			{	
				gameObject.BroadcastMessage("ReceiveBack");
			}
		}
	}
}