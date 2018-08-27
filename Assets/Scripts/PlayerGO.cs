using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// This is our Player's MAIN object (easier than using tags)
/// </summary>
public class PlayerGO : MonoBehaviour
{
    public Player player;
    public World world;

    public TMP_Text playerName;
    public TMP_Text worldText;
    public TMP_Text playerExtra;

    public TMP_Text text0;
    public TMP_Text text1;
    public TMP_Text text2;

    // Use this for initialization
    void Start()
    {
        player = ScriptableObject.CreateInstance<Player>();
        playerName.text = player.Name;


    }

    // Update is called once per frame
    void Update()
    {
        worldText.text = "100/100 Health";
        playerExtra.text = "100/100 Energy";
        text0.text = "Light Gun" + " 25/50 bullets";
        text1.text = Strings.Light(world.isLight);
        text2.text = Strings.Morph(world.isMorph);
    }
}
