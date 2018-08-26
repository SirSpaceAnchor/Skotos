using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameResource
{
    public static string Folder = "Game";

    public static void CreateGameGO()
    {
        //UnityEngine.Debug.Log("Loading GameGO ...");
        GameGO gameGOPrefab = Resources.Load<GameGO>(Folder + "/GameGOPrefab");
        if (gameGOPrefab == null)
        {
            UnityEngine.Debug.Log("Unable to find: GameGOPrefab");
            return;
        }
        GameGO.instance = null;
        GameGO gameGO = GameObject.Instantiate(gameGOPrefab);
        gameGO.name = "Game-GO";
        GameGO.instance = gameGO;
        UnityEngine.Debug.Log(gameGO.name + " was created");
        //GameObject.Destroy(gameGOPrefab);
    }
}
