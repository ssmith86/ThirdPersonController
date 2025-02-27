using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class JumpScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody rb;
    private bool isJumping;
    private int jumpCount;
    public float dashSpeed = 10f; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isJumping = false;
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            if(jumpCount > 1)
            {
                isJumping = true;
                
            }
            else
            {
                jumpCount++;
                rb.linearVelocity = new Vector3(0, 5, 0);
            }
           
        }

        if (Input.GetKeyDown(KeyCode.E) && isJumping)
        {
            rb.linearVelocity = new Vector3(0, 5, 0);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        jumpCount = 0;
        isJumping = false;
    }
}
