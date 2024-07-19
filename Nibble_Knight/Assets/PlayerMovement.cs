using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody rb;
    public float jumpForce;

    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();
    }

    //add frictionless material
    //add in grounded state for jumps
    //camera to ease and follow the player's momentum
    //coyote time and buffers
    void Update()
    {

        rb.velocity = new Vector3(Input.GetAxis("Horizontal")* moveSpeed, rb.velocity.y,0 );
        
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
        }
        if (Input.GetButtonUp("Jump")) {
            if(rb.velocity.x > 0)
                rb.velocity = new Vector3(rb.velocity.x, 0, 0);
        }
    }
}
