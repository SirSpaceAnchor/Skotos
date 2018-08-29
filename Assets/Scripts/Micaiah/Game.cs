using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    public static bool isPlayerLocked = false;
    public static bool isMenuActive = false;

    public static List<string> GetDisplays()
    {
        List<string> returns = new List<string>();
        returns.Add("isPlayerLocked: " + isPlayerLocked.ToString());
        returns.Add("isMenuActive: " + isMenuActive.ToString());
        return returns;
    }
}
