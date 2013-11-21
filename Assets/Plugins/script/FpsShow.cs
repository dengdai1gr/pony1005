using UnityEngine;
using System.Collections;

public class FpsShow : MonoBehaviour {
	private float a;
	private float timecount=0;
	public GUIStyle gs;
	private string fps;
	
	void Update()
	{
		a++;
		timecount+=Time.deltaTime;
		if(timecount>=0.5f)
		{	
			timecount=0;
			a=a/0.5f;
			fps=""+a.ToString();
			a=0;
		}
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(0,0,100,30),fps,gs);
	}
}




//	private string fps="";
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//		//fps=  (1f / Time.smoothDeltaTime).ToString("#,##0.0");
//		fps=  (1f / Time.smoothDeltaTime).ToString("#,##0");
//	}
//	
//	void OnGUI()
//	{
//		GUI.Label(new Rect(100,0,100,100),fps);
//	}
//}