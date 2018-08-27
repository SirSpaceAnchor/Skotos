using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPanel : MonoBehaviour
{
    public KeyPadGO displayKey;
    public RectTransform numContent;
    public KeyPadGO[] keys;
    public KeyPadGO zeroKey;
    public KeyPadGO clearKey;

    // Use this for initialization
    void Awake()
    {
        displayKey.nNumber = Numbers.Display;
        zeroKey.nNumber = Numbers.Zero;
        clearKey.nNumber = Numbers.Clear;
        keys = numContent.GetComponentsInChildren<KeyPadGO>();
        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].nNumber = (Numbers)i;
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