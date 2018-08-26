//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RigidMover : MonoBehaviour
//{
//    public Rigidbody rb;

//    // Use this for initialization
//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // COULD add in else here to avoid diagonals and other movements.
//        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
//        {
//            // MOVE forward.
//            transform.Translate(Vector3.forward);
//        }
//        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
//        {
//            // MOVE backwards.
//            transform.Translate(-Vector3.forward);
//        }

//        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
//        {
//            // MOVE left.
//            transform.Translate(-Vector3.right);
//        }
//        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
//        {
//            // MOVE right.
//            transform.Translate(Vector3.right);
//        }

//        if (Input.GetKeyDown(KeyCode.Q))
//        {
//            transform.Rotate(Vector3.up, -90);
//        }
//        if (Input.GetKeyDown(KeyCode.E))
//        {
//            float y = transform.eulerAngles.y;
//            transform.Rotate(Vector3.up, 90);
//        }

//        if (transform.eulerAngles.y % 90 == 0)
//        {

//        }
//        else
//        {

//        }
//    }
//}
