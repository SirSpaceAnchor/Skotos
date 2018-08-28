using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationParent : MonoBehaviour
{
    public GameObject[] gos;
    // Use this for initialization
    void Start()
    {
        List<GameObject> gameObjects = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            gameObjects.Add(transform.GetChild(i).gameObject);
        }
        gos = gameObjects.ToArray();
    }

    int i = 0;
    float timer = 0.25f;
    float timed = 0.25f;
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timed;
            Vector3 rotateY = gos[i].transform.eulerAngles;
            rotateY.y += 90;
            gos[i].transform.eulerAngles = rotateY;
            i++;
            if (i >= gos.Length)
            {
                i = 0;
            }
        }
    }
}
