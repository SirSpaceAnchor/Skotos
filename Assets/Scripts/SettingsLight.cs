using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skotos - Darkness
// Phos - Light

public class LightScriptableObject : ScriptableObject
{
}

[System.Serializable]
public class SettingsLight : Settings
{
    public readonly bool isLight = true;  // What is our default State?
    public bool isLightCurrent; // What is our Current light state?

    public SettingsLight(bool startLight = true)
    {
        this.isLight = startLight;
        isLightCurrent = isLight;
    }

    public override void LightSwitch(bool newlight)
    {
        if (allowLight)
        {
            isLightCurrent = newlight;
            base.LightSwitch(newlight);
        }
    }
}