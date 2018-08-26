using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGO : LightMonoBehaviour
{
    public Camera cam;
    public SettingsColor colorSettings;
    float colorLerp = 0.1f;

    private new void Awake()
    {
        base.Awake();
        colorSettings = new SettingsColor(cam.backgroundColor);
    }

    public override void LightSwitch(bool newLight)
    {
        base.LightSwitch(newLight);
        if (allowSwitch)
        {
            colorSettings.LightSwitch(newLight);
        }
    }
    //void 

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cam.backgroundColor != colorSettings.desiredColor)
        {
            cam.backgroundColor = Color32.Lerp(cam.backgroundColor, colorSettings.desiredColor, colorLerp);
        }
    }
}