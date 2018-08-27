using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LightType { Neutral, Light, Dark };

public class TileDamage : MonoBehaviour
{
    LightType lightType;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerGO>())
        {

        }
    }
}