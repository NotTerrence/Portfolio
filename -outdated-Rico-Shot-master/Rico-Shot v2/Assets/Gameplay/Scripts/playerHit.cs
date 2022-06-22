using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHit : MonoBehaviour {

    GameObject player;
    public gameOver over;

    // Use this for initialization
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Ball")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            SumScore.SaveHighScore();
            SumScore.Reset();
            GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

            for (var i = 0; i < balls.Length; i++)
                Destroy(balls[i]);

            over.playerHit();
        }
    }
}
