using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGO : MonoBehaviour
{
    public bool isLightCurrent = true;
    public Material mat;
    public Color originalColor;

    private void Awake()
    {
        World.OnLightChanged += LightChanged;
        mat = GetComponentInChildren<MeshRenderer>().material;
        originalColor = mat.color;
    }

    void LightChanged(bool newLight)
    {
        if (newLight)
        {
            mat.color = Colors.BrightenColor(mat.color, 55f);
        }
        else
        {
            mat.color = Colors.DarkenColor(mat.color, 55f);
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