using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGO : MonoBehaviour
{
    public FloorGO floorPrefab;

    private int width = 10;
    private int height = 10;

    private float tileWidth = 1.5f;
    private float tileDepth = 1.1f;

    // Use this for initialization
    void Start()
    {
        int i = 0;
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                FloorGO go = GameObject.Instantiate(floorPrefab);
                go.transform.SetParent(this.transform);
                go.transform.localScale = Vector3.one;
                go.transform.position = new Vector3(x * tileWidth, 0, z * tileDepth);
                if (i % 2 == 0)
                {
                    go.isLightCurrent = true;
                }
                else
                {
                    go.isLightCurrent = false;
                }
                i++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}