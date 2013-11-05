using UnityEngine;
using System.Collections;

public class Fps : MonoBehaviour {

	// Use this for initialization
	private string fps="";
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//fps=  (1f / Time.smoothDeltaTime).ToString("#,##0.0");
		fps=  (1f / Time.smoothDeltaTime).ToString("#,##0");
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(100,0,100,100),fps);
	}
}
