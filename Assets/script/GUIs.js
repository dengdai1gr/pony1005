#pragma strict

var toolgm:GameObject;

function Start () {

}

function Update () {

}

function OnGUI()
{
	if(GUI.Button(Rect(0,10,80,50),"Animation1"))
	{
		PlayAnimation1();
	}
	if(GUI.Button(Rect(0,60,80,50),"Animation2"))
	{
		PlayAnimation2();
	}
	
	if(GUI.Button(Rect(0,110,80,50),"Reset"))
	{
		Application.LoadLevel("Main 3");
	}
}






function PlayAnimation1()
{
	toolgm.SendMessage("PlayAnimation");
	yield WaitForSeconds(0.1f);
	
	var pony:GameObject= GameObject.Find("PonyAnimationTest_02"); 
	pony.animation.Play("Take03");
	yield WaitForSeconds(pony.animation.clip.length*4);
	pony.animation.Play("Take01");
}

function PlayAnimation2()
{
	toolgm.SendMessage("PlayAnimation");
	yield WaitForSeconds(0.1f);
	
	var pony:GameObject= GameObject.Find("PonyAnimationTest_02"); 
	pony.animation.Play("Take02");
	yield WaitForSeconds(pony.animation.clip.length*4);
	pony.animation.Play("Take01");
}