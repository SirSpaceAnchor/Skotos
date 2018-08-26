using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // COULD add in else here to avoid diagonals and other movements.
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            // MOVE forward.
            transform.Translate(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            // MOVE backwards.
            transform.Translate(-Vector3.forward);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // MOVE left.
            transform.Translate(-Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            // MOVE right.
            transform.Translate(Vector3.right);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -90);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            float y = transform.eulerAngles.y;
            transform.Rotate(Vector3.up, 90);
        }

        if (transform.eulerAngles.y % 90 == 0)
        {

        }
        else
        {
            // TODO if (between 80 and 100 make 90
            float yEuler = transform.eulerAngles.y;
            if (yEuler <= 20 && yEuler >= -10)
            {
                yEuler = 0;
            }
            if (yEuler <= 100 && yEuler >= 80)
            {
                yEuler = 90;
            }
            if (yEuler <= 200 && yEuler >= 170)
            {
                yEuler = 180;
            }
            if (yEuler <= 290 && yEuler >= 250)
            {
                yEuler = 270;
            }
            //UnityEngine.Debug.Log("Y Angle: " + .ToString());
            //int angle = Mathf.FloorToInt(transform.eulerAngles.y) / (int)90;
            //transform.eulerAngles = new Vector3(0, angle * 90, 0);
            transform.eulerAngles = new Vector3(0, yEuler, 0);
        }

    }
}
