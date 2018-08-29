using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInput : MonoBehaviour
{
    // Set this in the Inspector from our Premade World
    public World world;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //AudioManager.instance.Play(StatusType.WakeUp.ToString(), true);
            world.ChangeLight();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            world.ChangeMorph();
        }
    }

    //// Use this for initialization
    //void Start()
    //{
    //}
}