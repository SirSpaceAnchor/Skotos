using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings
{
    public bool allowLight = true; // true; allows the object to change phases
    public bool allowMorph = true; // true; allows the object to change morphs

    public virtual void LightSwitch(bool newlight)
    {

    }

    public virtual void MorphSwitch(bool newMorph)
    {

    }
}

[System.Serializable]
public class SettingsColor : Settings
{
    public readonly Color32 currentColor;
    public Color32 desiredColor;
    public Color32 lightColor;
    public Color32 darkColor;

    public SettingsColor(Color32 currentLightColor)
    {
        currentColor = currentLightColor;
        lightColor = currentColor;
        desiredColor = lightColor;
        darkColor = Colors.DarkenColor(currentLightColor, World.LightColorStrength);
    }

    public override void LightSwitch(bool newLight)
    {
        if (allowLight)
        {
            if (newLight)
            {
                desiredColor = lightColor;
            }
            else
            {
                desiredColor = darkColor;
            }
        }
    }
}