using FC;
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
            keys[i].button.interactable = false;
        }
        Activate(false);
    }

    //// Use this for initialization
    //void Start()
    //{
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}


    private void OnTriggerEnter(Collider other)
    {
        PlayerControl player = other.GetComponent<PlayerControl>();
        Camera.main.transform.LookAt(this.transform.position);
        if (player != null)
        {
            UnityEngine.Debug.Log("Player is Locked to DoorPanel.");
            Game.isPlayerLocked = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Activate(Game.isPlayerLocked);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerControl player = other.GetComponent<PlayerControl>();
        if (player != null)
        {
            UnityEngine.Debug.Log("Player is UnLocked from DoorPanel.");
            Game.isPlayerLocked = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            Activate(Game.isPlayerLocked);
        }
    }

    private void Activate(bool isActivated)
    {
        displayKey.button.interactable = isActivated;
        zeroKey.button.interactable = isActivated;
        clearKey.button.interactable = isActivated;
        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].button.interactable = isActivated;
        }
    }
}