﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// No sound until done eating, nom nom nom (hotdogs weren't fufilling, so had some
// cottage cheese and peaches, YUM
// Almost there, few more minutes

/// <summary>
/// A generic button to do something
/// This is sitting on things without buttons
/// </summary>
public class ButtonGO : LightMonoBehaviour
{
    public Button button; // can be null!
    public Image image;
    public string text;
    public TMP_Text textObject;

    // Use this for initialization
    public new void Awake()
    {
        textObject = GetComponentInChildren<TMP_Text>();
        image = GetComponent<Image>();
        base.Awake();
    }

    /// <summary>
    /// External to the Button, we response to light Changes (Default for all buttons)
    /// </summary>
    /// <param name="newLight"></param>
    public override void LightSwitch(bool newLight)
    {
        base.LightSwitch(newLight);
        if (lightLast == newLight)
        {
            // We haven't changed so don't do anything.
        }
        else if (isLightCurrent)
        {
            textObject.color = Color.black;
            image.color = Color.white;
        }
        else
        {
            textObject.color = Color.white;
            image.color = Color.black;
        }
        lightLast = isLightCurrent;
    }

    // Update is called once per frame
    void Update()
    {
        textObject.text = text;
    }
}
