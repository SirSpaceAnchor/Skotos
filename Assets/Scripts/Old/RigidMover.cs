using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidMover : MonoBehaviour
{
    public Rigidbody rb;
    private int speed = 12;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // COULD add in else here to avoid diagonals and other movements.
        //float x = Input.GetAxis("Horizontal");
        //if (x != 0)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // MOVE forward.
            //rb.AddForce(Vector3.forward);
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // MOVE backwards.
            //rb.AddForce(-Vector3.forward);
            rb.MovePosition(transform.position - transform.forward * Time.deltaTime * speed);
            //transform.Translate(-Vector3.forward);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // MOVE left.
            //transform.Translate(-Vector3.right);
            rb.MovePosition(transform.position - transform.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // MOVE right.
            //transform.Translate(Vector3.right);
            rb.MovePosition(transform.position + transform.right * Time.deltaTime * speed);
        }
    }
}
