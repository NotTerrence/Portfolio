using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gameOver : MonoBehaviour {

	// Use this for initialization
    public GameObject GameOver;
	void Start () {
        GameOver.active = false;
	}

    public void playerHit()
    {
        GameOver.active = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
