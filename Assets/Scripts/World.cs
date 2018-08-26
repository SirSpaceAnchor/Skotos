using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skotos/World")]
public class World : ScriptableObject
{
    public const float LightColorStrength = 55;
    public bool isLight;
    public bool isMorph;
    // public bool isLabDoorOpen; (IDEA for future)

    List<ButtonGO> buttons;
    List<CubeGO> worldObjects;

    /// <summary>
    /// isLight = true (Light Phased)
    /// </summary>
    public static Action<bool> OnLightChanged;
    /// <summary>
    /// isMorph = true (Big Size Phased)
    /// </summary>
    public static Action<bool> OnMorphChanged;
    /// <summary>
    /// isDoorLocked == false; (Door is Ajar)
    /// </summary>
    public static Action<bool> OnLabDoorChanged;

    public void Reset()
    {
        isLight = true;
        isMorph = true;
    }

    public void Apply()
    {
        if (OnLightChanged != null)
        {
            OnLightChanged(isLight);
        }
        if (OnMorphChanged != null)
        {
            OnMorphChanged(isMorph);
        }
    }

    public void ChangeLight()
    {
        isLight = !isLight;
        Apply();
    }

    public void ChangeMorph()
    {
        isMorph = !isMorph;
        Apply();
    }

}
