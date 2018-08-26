using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Strings
{
    public const string OPENED = "OPENED"; //KeyPad Access
    public const string LOCKED = "LOCKED";
    public const string ERROR = "ERROR";
    public const string DoorLockCODE = "00";

    public const string GameMenu = "Menu";
    public const string GameLabs = "Labs";
    public const string GameGame = "Game";

    public static string Morph(bool isMorph)
    {
        if (isMorph)
        {
            return "Shrink";
        }
        else
        {
            return "Grow";
        }
    }

    public static string Light(bool isLight)
    {
        if (isLight)
        {
            return "Light";
        }
        else
        {
            return "Dark";
        }
    }

    public static string LightOpposite(bool isLight)
    {
        bool opposite = !isLight;
        return Light(opposite);
    }
}
