using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGO : MonoBehaviour
{
    public GameObject door;
    public Material mat;

    private void Awake()
    {
        mat = door.GetComponent<MeshRenderer>().material;
        World.OnLabDoorChanged += LabDoorChanged;
    }

    private void LabDoorChanged(bool isDoorLocked)
    {
        UnityEngine.Debug.Log("Door is now: " + (isDoorLocked == true ? "Locking" : "Opening"));
        if (isDoorLocked == false)
        {
            mat.color = Color.black;
        }
        else
        {
            mat.color = Color.white;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}