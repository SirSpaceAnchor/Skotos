using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LabsDoorEnter : MonoBehaviour
{
    public BoxCollider colliderEnter;

    private void Awake()
    {
        World.OnLabDoorChanged += LabDoorChanged;
    }

    private void LabDoorChanged(bool isDoorLocked)
    {
        if (isDoorLocked == false)
        {
            colliderEnter.isTrigger = true;
        }
        else
        {
            colliderEnter.isTrigger = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PersonController pc = other.GetComponent<PersonController>();
        if (pc != null)
        {
            SceneManager.LoadScene(Strings.GameGame);
        }
    }

    //// Use this for initialization
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}