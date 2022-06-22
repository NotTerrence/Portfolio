using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{

    public Button dashButton;
    public static float time;

    public float dashRate = 1;
    public float dashTime = 5;
    private bool nextDash = true;


    private Rigidbody rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
      
        Button btn1 = dashButton.GetComponent<Button>();
        btn1.onClick.AddListener(dash);
    }

    void dash()
    {

        if (nextDash)
        {
            Debug.Log("Dash!");
            //rb.velocity = new Vector3(10f, 0f, 10f);
            rb.AddForce(transform.forward * dashRate, ForceMode.Impulse);
            nextDash = false;
            StartCoroutine("Example");
        }

    }


    IEnumerator Example()
    {
        yield return new WaitForSeconds(dashTime);
        nextDash = true;
    }
}
