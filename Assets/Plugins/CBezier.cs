using UnityEngine;

public class CBezier : MonoBehaviour

{

    private Bezier myBezier;
	private CustomLineRenderer line;
	public Material material;
	public float p1xsl;
	public float p1ysl;
	public float p2xsl;	
	public float p2ysl;	
	public float p3xsl;	
	public float p3ysl;	
	public GameObject[] cubes;	
	public int linecount=45;
	public float startw=1.5f;
	public float endw=1.5f;
	
	
	void Start(){

		line = GetComponent<CustomLineRenderer>();
		line.SetVertexCount(linecount);
		line.SetWidth(startw,endw);
		line.renderer.sharedMaterial=material;
		
    }
	
    void FixedUpdate()
    {
		//tests
		//	float offset = Time.time * scrollSpeed;
		//line.renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));

       	myBezier = new Bezier( new Vector3( 0, 0, 0f ), new Vector3(p1xsl,p1ysl,0) ,new Vector3(p2xsl,p2ysl,0), new Vector3( p3xsl, p3ysl, 0f ) );
		for(int i =0; i < linecount; i++)
		{
			Vector3 vec = myBezier.GetPointAtTime( (float)(i *(1.0f/linecount)) );		
			line.SetPosition(i,vec);
				vec.z=0;
			//Debug.DrawLine(vec, Camera.mainCamera.transform.position);
			
			
			if(i==3)
			{		
				cubes[0].transform.localPosition=vec;
			}
			if(i==6)
			{		
				cubes[1].transform.localPosition=vec;
			}
			if(i==9)
			{		
				cubes[2].transform.localPosition=vec;
			}
			if(i==12)
			{		
				cubes[3].transform.localPosition=vec;
			}
			
			if(i==15)
			{		
				cubes[4].transform.localPosition=vec;
			}	
			if(i==18)
			{		
				cubes[5].transform.localPosition=vec;
			}
			if(i==21)
			{		
				cubes[6].transform.localPosition=vec;
			}
			if(i==24)
			{		
				cubes[7].transform.localPosition=vec;
			}
			if(i==27)
			{		
				cubes[8].transform.localPosition=vec;
			}
			
			if(i==30)
			{		
				cubes[9].transform.localPosition=vec;
			}
			
			if(i==34)
			{		
				cubes[10].transform.localPosition=vec;
			}
			
//			if(i==39)
//			{		
//				cubes[12].transform.localPosition=vec;
//			}

		}
		
	}
}