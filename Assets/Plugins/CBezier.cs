using UnityEngine;

public class CBezier : MonoBehaviour

{

    private Bezier myBezier;
 	CustomLineRenderer line;
	public Material material;
	public Material middlemat;
	public float p1xsl;
	public float p1ysl;
	public float p2xsl;	
	public float p2ysl;	
	public float p3xsl;	
	public float p3ysl;	
	public GameObject[] cubes;	
	public int linecount=45;
	public Vector3[] vec;
	
	//public GameObject[] test;
	
	
	void Start(){

		line = GetComponent<CustomLineRenderer>();
		line.SetVertexCount(linecount);
		line.SetWidth(1.5f,1.5f);
		line.renderer.sharedMaterial=material;
		
    }
	
    //void FixedUpdate()
	void Update()
    {
		//tests
		//float offset = Time.time * 0.05f;
		//line.renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, offset));

       	myBezier = new Bezier( new Vector3( 0, 0, 0f ), new Vector3(p1xsl,p1ysl,0) ,new Vector3(p2xsl,p2ysl,0), new Vector3( p3xsl, p3ysl, 0f ) );
		for(int i =0; i < linecount; i++)
		{
			
			
			//test[0].transform.localPosition=new Vector3(p3xsl+p2xsl,p3ysl+p2ysl,0);
			//test[1].transform.localPosition=new Vector3(p3xsl,p3ysl,0);
				
//			Vector3 vec = myBezier.GetPointAtTime( (float)(i *(1.0f/linecount)) );		
//			line.SetPosition(i,vec);
//			vec.z=0;
			//Debug.DrawLine(vec, Camera.mainCamera.transform.position);
			vec[i] = myBezier.GetPointAtTime( (float)(i *(1.0f/linecount)) );		
			line.SetPosition(i,vec[i]);
			vec[i].z=0;
			
			if(i==1)
			{		
				cubes[0].transform.localPosition=vec[i];
			}
			if(i==4)
			{		
				cubes[1].transform.localPosition=vec[i];
			}
			if(i==7)
			{		
				cubes[2].transform.localPosition=vec[i];
			}
//			if(i==12)
//			{		
//				cubes[3].transform.localPosition=vec[i];
//			}
			
			
			if(i==9)
			{		
				cubes[3].transform.localPosition=vec[i];
			}	
			if(i==12)
			{		
				cubes[4].transform.localPosition=vec[i];
			}
			if(i==15)
			{		
				cubes[5].transform.localPosition=vec[i];
			}
//			if(i==24)
//			{		
//				cubes[7].transform.localPosition=vec[i];
//			}
//			if(i==27)
//			{		
//				cubes[8].transform.localPosition=vec[i];
//			}
//			
//			
//			if(i==30)
//			{		
//				cubes[9].transform.localPosition=vec[i];
//			}
			
			if(i==18)
			{		
				cubes[6].transform.localPosition=vec[i];
			}
			
//			if(i==39)
//			{		
//				cubes[12].transform.localPosition=vec;
//			}
			
			
			
		}
		
	}
	
	public void ChangeMatM()
	{
	//	line.renderer.sharedMaterial=middlemat;
	}
	
//	public void ChangeMatS()
//	{
//		line.renderer.sharedMaterial=shortmat;
//	}
	
	
}