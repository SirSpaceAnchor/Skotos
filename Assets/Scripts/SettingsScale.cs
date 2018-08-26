using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScale : Settings
{
    public float currentScale = 1.0f;
    public float desiredScale = 1.0f;

    public SettingsScale(float newScale)
    {
        currentScale = newScale;
        desiredScale = currentScale;
    }
}
