using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// TODO: Add in security mesaures

public class KeyPadGO : MonoBehaviour
{
    public Button button;
    public Numbers nNumber = Numbers.One;
    int number = 1;
    string text = "A, B, C";
    public TMP_Text keyText;
    public TMP_Text alphaText;

    public static bool isDoorLocked = true;
    public static string AccessCode = "4337";
    public static string CurrentCode;
    public LayoutElement le;

    // Use this for initialization
    void Start()
    {
        le = GetComponent<LayoutElement>();
        CurrentCode = Strings.LOCKED;
        isDoorLocked = true;
        button = GetComponent<Button>();
        if (button == null)
        {
            button = gameObject.AddComponent<Button>();
        }
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(PressKey);
        number = Enums.Number(nNumber);
        text = Enums.NumberString(nNumber);
        if (nNumber == Numbers.Display || nNumber == Numbers.Clear || nNumber == Numbers.Zero)
        {
            alphaText.gameObject.SetActive(false);
            if (nNumber == Numbers.Display)
            {
                le.ignoreLayout = true;
            }
            else
            {
                le.ignoreLayout = false;
            }
            keyText.gameObject.SetActive(true);
            alphaText.gameObject.SetActive(false);
        }
        else
        {
            le.ignoreLayout = false;
            keyText.gameObject.SetActive(true);
            alphaText.gameObject.SetActive(true);
        }

        switch (nNumber)
        {
            case Numbers.One:
                number = 1;
                text = "A, B, C";
                break;
            case Numbers.Two:
                number = 2;
                text = "D, E, F";
                break;
            case Numbers.Three:
                number = 3;
                text = "G, H, I";
                break;
            case Numbers.Four:
                number = 4;
                text = "J, K, L";
                break;
            case Numbers.Five:
                number = 5;
                text = "M, N, O";
                break;
            case Numbers.Six:
                number = 6;
                text = "P, Q, R";
                break;
            case Numbers.Seven:
                number = 7;
                text = "S, T, U";
                break;
            case Numbers.Eight:
                number = 8;
                text = "V, W, X";
                break;
            case Numbers.Nine:
                number = 9;
                text = "Y, Z";
                break;
            case Numbers.Zero:
                number = 0;
                text = number.ToString();
                break;
            case Numbers.Display:
                text = nNumber.ToString();
                break;
            case Numbers.Clear:
                text = nNumber.ToString();
                break;
        }
        if (nNumber == Numbers.Display || nNumber == Numbers.Clear || nNumber == Numbers.Zero)
        {
            keyText.text = text;
            alphaText.text = "";
        }
        else
        {
            keyText.text = number.ToString();
            alphaText.text = text;
        }
    }

    /// <summary>
    /// Pressing 00 while door is locked, locks it again
    /// </summary>
    public void PressKey()
    {
        if (nNumber == Numbers.Clear)
        {
            if (isCodeString() == false)
            {
                CurrentCode = "";
            }
        }
        else if (isDoorLocked == false)
        {
            if (nNumber == Numbers.Zero)
            {
                EnterKey(number.ToString());
            }
        }
        else
        {
            // is Door is Locked, don't accept Zero as key.
            if (nNumber != Numbers.Zero)
            {
                EnterKey(number.ToString());
            }
        }
    }

    public bool isCodeString()
    {
        if (CurrentCode == Strings.LOCKED
            || CurrentCode == Strings.OPENED
            || CurrentCode == Strings.ERROR
            || CurrentCode == Strings.DoorLockCODE
            )
        {
            return true;
        }
        return false;
    }

    public void EnterKey(string k)
    {
        if (isCodeString())
        {
            CurrentCode = "";
        }
        CurrentCode += number.ToString();
        if (CurrentCode.Length > 6)
        {
            CurrentCode = Strings.ERROR;
        }
        UnityEngine.Debug.Log("Code: " + CurrentCode.ToString());
    }

    void LockDoor()
    {
        CurrentCode = Strings.LOCKED;
        isDoorLocked = true;
        if (World.OnLabDoorChanged != null)
        {
            World.OnLabDoorChanged(isDoorLocked);
        }
    }

    void UnlockDoor()
    {
        isDoorLocked = false;
        CurrentCode = "";
        if (World.OnLabDoorChanged != null)
        {
            World.OnLabDoorChanged(isDoorLocked);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (nNumber == Numbers.Display)
        {
            if (CurrentCode == Strings.DoorLockCODE)
            {
                LockDoor();
                return;
            }
            else if (isDoorLocked)
            {
                keyText.text = CurrentCode;
                if (CurrentCode == AccessCode)
                {
                    UnlockDoor();
                }
            }
            else
            {
                keyText.text = Strings.OPENED;
            }
        }
    }
}
