using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://unity3d.com/learn/tutorials/topics/multiplayer-networking/setting-player-prefab?playlist=29690

public class HealthSystem : MonoBehaviour
{
    public Player player;
    public Image controlImage;
    public Image healthImage;

    // Use this for initialization
    void Start()
    {
        controlImage.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (player.isDead == false)
            {
                if (player.HealthMax <= 0)
                {
                    player.HealthMax = 100;
                }
                healthImage.fillAmount = player.Health / (float)player.HealthMax;
            }
            else
            {
                controlImage.gameObject.SetActive(false);
            }
        }
    }
}