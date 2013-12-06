#pragma strict

var toolgm:GameObject;
var hairmat:Material;
var t1:Texture;
var t2:Texture;
var t3:Texture;
var t4:Texture;
var i=0;

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
	if(GUI.Button(Rect(0,160,80,50),"ChangeMat"))
	{
		if(i<3)
		{	
			i++;		
		}
		else
		{
			i=0;
		}
		ChangeHair(i);
	}
}


function ChangeHair(i:int)
{
	if(i==0)
		hairmat.mainTexture=t1;
	else if(i==1)
		hairmat.mainTexture=t2;
	else if(i==2)
		hairmat.mainTexture=t3;
	else {
		hairmat.mainTexture=t4;
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