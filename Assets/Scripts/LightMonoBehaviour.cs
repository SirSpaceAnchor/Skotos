using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMonoBehaviour : MonoBehaviour
{
    public bool lightLast;
    public bool isLightCurrent = true;
    public bool allowSwitch = true;
    public void Awake()
    {
        lightLast = isLightCurrent;
        World.OnLightChanged += LightSwitch;
    }

    public virtual void LightSwitch(bool newLight)
    {
        if (allowSwitch)
        {
            isLightCurrent = newLight;
        }
    }

    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}
}