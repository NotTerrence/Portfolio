using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{
    public bool onGround;
    private Rigidbody rb;
    public Button jumpButton;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Button btn1 = jumpButton.GetComponent<Button>();
        btn1.onClick.AddListener(doJump);
    }

    void doJump()
    {
        if (onGround)
        {
            rb.velocity = new Vector3(0f, 10f, 0f);
            onGround = false;
        }
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }


}