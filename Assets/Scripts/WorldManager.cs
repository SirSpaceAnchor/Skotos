using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager instance;

    public World world; // How does objects know about the world.
    public ButtonGO lightButton;
    public ButtonGO morphButton;

    private void Awake()
    {
        instance = this;
        world.Reset();
    }

    // Use this for initialization
    void Start()
    {
        if (lightButton != null)
        {
            lightButton.button.onClick.RemoveAllListeners();
            lightButton.button.onClick.AddListener(ChangeLight);
            lightButton.text = Strings.Light(world.isLight);
        }
        if (morphButton != null)
        {
            morphButton.button.onClick.RemoveAllListeners();
            morphButton.button.onClick.AddListener(ChangeMorph);
            morphButton.text = Strings.Morph(world.isMorph);
        }
        world.Apply();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeLight()
    {
        world.ChangeLight();
        if (lightButton != null)
        {
            lightButton.text = Strings.Light(world.isLight);
        }
    }

    public void ChangeMorph()
    {
        world.ChangeMorph();
        if (morphButton != null)
        {
            morphButton.text = Strings.Morph(world.isMorph);
        }
    }

    public static bool isLight
    {
        get
        {
            return instance.world.isLight;
        }
    }

    public static bool isMorph
    {
        get
        {
            return instance.world.isMorph;
        }
    }
}
