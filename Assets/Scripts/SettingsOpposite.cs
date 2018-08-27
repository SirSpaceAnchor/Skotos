using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingsOpposite : MonoBehaviour
{
    public TMP_Text textObject;

    private void Awake()
    {
        textObject = GetComponent<TMP_Text>();
        World.OnLightChanged += LightChanged;
    }

    void LightChanged(bool newLight)
    {
        if (newLight)
        {
            textObject.color = Color.black;
        }
        else
        {
            textObject.color = Color.white;
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