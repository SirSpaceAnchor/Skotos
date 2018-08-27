using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGO : MonoBehaviour
{
    public LightType lightType = LightType.Neutral;
    public MeshRenderer meshToChange;
    public Material mat;
    public Color originalColor;

    private void Awake()
    {
        World.OnLightChanged += LightChanged;
        mat = meshToChange.material;
        originalColor = mat.color;
        LightChanged(true);
    }

    void LightChanged(bool newLight)
    {
        if (newLight)
        {
            switch (lightType)
            {
                case LightType.Neutral:
                    mat.color = Color.grey;
                    break;
                case LightType.Light:
                    mat.color = Color.black;
                    break;
                case LightType.Dark:
                    mat.color = Color.white;
                    break;
            }
        }
        else
        {
            switch (lightType)
            {
                case LightType.Neutral:
                    mat.color = Color.grey;
                    break;
                case LightType.Light:
                    mat.color = Color.white;
                    break;
                case LightType.Dark:
                    mat.color = Color.black;
                    break;
            }
            //mat.color = Colors.DarkenColor(mat.color, 55f);
        }
    }

    // Use this for initialization
    void Start()
    {
        LightChanged(true);
        TileDamage tileDamage = GetComponentInChildren<TileDamage>();
        if (tileDamage != null)
        {
            tileDamage.lightType = LightType.Light;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}