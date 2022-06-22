using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    public float jumpForce = 2f;
    public BoxCollider col;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
        Invoke("Jump", 2);
    }

    void Jump()
    {
        if (IsGrounded())
        {
            Debug.Log("UP");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        Invoke("Jump", Random.Range(0, 20));
    }
    private bool IsGrounded()
    {
        return Physics.CheckBox(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z));
    }
}
