using UnityEngine;
using System.Collections;

public class ToolPic : MonoBehaviour {

	public Texture2D img;
	public Texture2D imglight;
	
	void Start () {
	
		gameObject.renderer.material.mainTexture=img;
	}
	
	void Update () {
	
	}
	
	void IsSelect()
	{
		gameObject.renderer.material.mainTexture=imglight;
	}
	void NoSelect()
	{
		gameObject.renderer.material.mainTexture=img;
	}
	
}
