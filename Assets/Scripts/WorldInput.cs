using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInput : MonoBehaviour
{
    // Set this in the Inspector from our Premade World
    public World world;
    //// Use this for initialization
    //void Start()
    //{
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            world.ChangeLight();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            world.ChangeMorph();
        }
    }
}