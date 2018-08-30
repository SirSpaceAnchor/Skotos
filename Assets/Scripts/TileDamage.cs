using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LightType { Neutral, Light, Dark };

public class TileDamage : MonoBehaviour
{
    // Example if (WorldManager.isLight && lightType != LightType.Light)
    public LightType lightType; 
    int strength = 1;
    float lastTime = 0f;

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
        PlayerBaseGO playerGO = other.GetComponent<PlayerBaseGO>();
        if (playerGO != null)
        {
            //UnityEngine.Debug.Log("Player Entered Tile");
            UnityEngine.Debug.Log("W: " + WorldManager.isLight.ToString() + " vs " + lightType.ToString());
            //if (Time.time - lastTime < 1)
            //{
            //    return;
            //}
            if (lightType == LightType.Neutral)
            {

            }
            else if (WorldManager.isLight && lightType == LightType.Light)
            {

            }
            else if (WorldManager.isLight == false && lightType == LightType.Dark)
            {
            }
            else
            {
                UnityEngine.Debug.Log("Player Entered Tile");
                playerGO.TakeDamage(strength);
                lastTime = Time.time;
            }
        }
    }
}