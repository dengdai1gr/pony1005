using UnityEngine;
using System.Collections;

public class Pub : MonoBehaviour {
	
	//public static bool iscontrol;
	public static bool istoolcut;
	public static bool istoolbrush;
	public static bool istoolrazor;
	public static bool istoolblow;
	
	void Start () {
	
		Tools.HitTool+=CheckTool;
		CheckTool(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void CheckTool(int number)
	{
		//print (number);
		switch(number)
		{
		case 0:
			//iscontrol=true;
			istoolcut=false;
			istoolbrush=false;
			istoolrazor=false;
			istoolblow=false;
			break;
		case 1:
			//iscontrol=false;
			istoolcut=true;
			istoolbrush=false;
			istoolrazor=false;
			istoolblow=false;
			break;
			
		case 2:
			//iscontrol=false;
			istoolcut=false;
			istoolbrush=true;
			istoolrazor=false;
			istoolblow=false;
			break;
			 
		case 3:
			//iscontrol=false;
			istoolcut=false;
			istoolbrush=false;
			istoolrazor=true;
			istoolblow=false;
			break;
			
		case 4:
			//iscontrol=false;
			istoolcut=false;
			istoolbrush=false;
			istoolrazor=false;
			istoolblow=true;
			break;
			
		}
	}
	
	
}
