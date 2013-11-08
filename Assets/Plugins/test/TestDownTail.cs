using UnityEngine;
using System.Collections;

public class TestDownTail : MonoBehaviour {

	
	public CBezier[] cbezier;
	public ControlHair[] ch;
	
	void Start () {
	
			cbezier=gameObject.GetComponentsInChildren<CBezier>();
			ch=gameObject.GetComponentsInChildren<ControlHair>();
	}
	
	// Update is called once per frame
	void Update () {
	
		
		if(Input.GetKeyDown("d")|| Input.touchCount==3)
		{
			Change ();
		}
	}
	
	
	
	void Change()
	{
		foreach(CBezier cb in cbezier)
		{
			//cb.p3ysl-=0.5f;//-22.49
			LeanTween.value(gameObject,fc,cb.p3ysl, -22.49f, 2f, new object[]{ "ease",LeanTweenType.easeOutQuint });
			
			LeanTween.value(gameObject,fcp1,cb.p1ysl, -6f, 2f, new object[]{ "ease",LeanTweenType.easeOutQuint });//p1
			
			
		}
	}
	
	
	
	void fc(float a)
	{
		foreach(CBezier cb in cbezier)
		{
			cb.p3ysl=a;
		}
		foreach(ControlHair cth in ch)
		{
			cth.CheckMaxDis();
		}
		
	}
	
	void fcp1(float a)
	{
		foreach(CBezier cb in cbezier)
		{
			cb.p1ysl=a;
		}
		
		
		foreach(ControlHair cth in ch)
		{
			cth.CheckMaxDis();
		}
	}
}
