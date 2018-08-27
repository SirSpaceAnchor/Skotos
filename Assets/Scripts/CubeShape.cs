using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShapeTyoe { ThreeByThree, OneByThree, ThreeByOne, TwoByTwo, OneByTwo, TwoByOne, OneByOne };

public class CubeShape : MonoBehaviour
{
    public ShapeTyoe shapeType;
    public CubeGO[] cubes;
    //List<Vector3> objects
    // if objects.contains(newpos)
    // Destroy Object

    private void Awake()
    {
        cubes = GetComponentsInChildren<CubeGO>();
        switch (shapeType)
        {
            case ShapeTyoe.ThreeByThree:
                BuildBy(3, 3);
                break;
            case ShapeTyoe.OneByThree:
                BuildBy(0, 3);
                break;
            case ShapeTyoe.ThreeByOne:
                BuildBy(3, 0);
                break;
            case ShapeTyoe.TwoByTwo:
                BuildBy(2, 2);
                break;
            case ShapeTyoe.OneByTwo:
                BuildBy(0, 2);
                break;
            case ShapeTyoe.TwoByOne:
                BuildBy(2, 0);
                break;
            case ShapeTyoe.OneByOne:
                BuildBy(1, 1);
                break;
        }
    }

    void BuildBy(int width, int height)
    {
        int x = 0;
        int z = 0;
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].transform.position = new Vector3(x, transform.position.y, z);
            x++;
            if (x > width)
            {
                x = 0;
                z++;
                if (z > height)
                {
                    z = 0;
                }
            }
        }
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}