using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Our labs Personage.
/// ONLY for labs
/// </summary>
public class PersonController : MonoBehaviour
{
    private void Awake()
    {
        GameGO.Check();
    }

    // Use this for initialization
    void Start()
    {
        // Some race problems with GameGO
        //GameGO.Check();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
