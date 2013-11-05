using UnityEngine;
using System.Collections;

public class FpsShow : MonoBehaviour {
	private float a;
	private float timecount=0;
	//public TextMesh FPS;
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

