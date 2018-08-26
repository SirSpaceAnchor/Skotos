using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ColorSettings
// Color Requires
// Writes to a Cube BASE

// Skotos - Darkness
// Phos - Light

[System.Serializable]
public class Cube //: ScriptableObject
{
    public Material material;

    public SettingsPosition positionSettings;
    public SettingsColor colorSettings;
    public SettingsLight lightSettings;
    public SettingsScale scaleSettings;

    public Cube(Vector3 startOffset, Vector3 startRot, bool startLight = true, float startScale = 1.0f)
    {
        positionSettings = new SettingsPosition(startOffset, startRot);
        lightSettings = new SettingsLight(startLight);
        scaleSettings = new SettingsScale(startScale);
    }

    public void SetStart(MeshRenderer mesh)
    {
        material = mesh.material;
        colorSettings = new SettingsColor(material.color);
    }

    public void Switch()
    {
        if (lightSettings.allowLight == false)
            return;

        lightSettings.LightSwitch(!lightSettings.isLightCurrent);
        UnityEngine.Debug.Log("Switching to: " + Strings.Light(lightSettings.isLightCurrent));
        //Strings.LightOpposite(lightSettings.isLightCurrent));
        colorSettings.LightSwitch(lightSettings.isLightCurrent);
    }

    void Tick()
    {

    }
}
