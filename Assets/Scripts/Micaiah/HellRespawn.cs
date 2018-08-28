using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellRespawn : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = Vector3.zero;
    }
}