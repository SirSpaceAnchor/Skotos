using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 0 - True
/// 1 - False (Any non-zero value)
/// </summary>
public static class Strings
{
    public const string OPENED = "OPENED"; //KeyPad Access
    public const string LOCKED = "LOCKED";
    public const string ERROR = "ERROR";
    public const string DoorLockCODE = "00";

    public const string Space = " ";

    public const string GameMenu = "Menu_5.6.6"; // Remove -5.6.6 for 2018.2
    public const string GameLabs = "Labs_5.6.6"; // Remove -5.6.6 for 2018.2
    //public const string GameGame = "Level_0_5.6.6"; // Remove -5.6.6 for 2018.2
    public const string GameGame = "Level_Random";

    public const string GameIntro_0 = "Show me how I got here!";
    public const string GameIntro_1 = "I don't need no intro";
    public const string GameStory_0 = "Time to work on Project Light";
    public const string GameStory_1 = "ITs just a door code, not a Leet, let me guess.";

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
