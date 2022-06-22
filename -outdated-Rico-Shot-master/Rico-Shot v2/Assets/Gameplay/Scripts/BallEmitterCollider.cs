using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEmitterCollider : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collide!");
        if(col.gameObject)
        {
            Debug.Log("Collide!");

        }
            
    }
}
