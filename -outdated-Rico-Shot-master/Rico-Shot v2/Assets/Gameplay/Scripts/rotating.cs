using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotating : MonoBehaviour {


public float speed = 5f;
public int rotation = 0;
public float start = 0; 
	// Use this for initialization
	void Start () {
		
		start = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		//System.Random rnd = new System.Random();
		// rotation = rnd.Next(1 , 50);
		 print(start );
		 print(Time.fixedTime);
		 if(start +40f <= Time.fixedTime)
		 {
			 start= Time.fixedTime;
			 if(rotation == 1)
				 rotation = 0;
			 else 
				 rotation = 1;
		 }
		if(rotation == 0)
		{transform.Rotate(2*Time.deltaTime*speed,0,0);}
	  else if(rotation == 1)
	  {transform.Rotate(0,0,2*Time.deltaTime*speed);}
	 //  else
	  // {transform.Rotate(0,20*Time.deltaTime*speed,0);}
	}
}
