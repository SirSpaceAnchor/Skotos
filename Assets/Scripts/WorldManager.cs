using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public World world; // How does objects know about the world.
    public ButtonGO lightButton;
    public ButtonGO morphButton;

    private void Awake()
    {
        world.Reset();
    }

    // Use this for initialization
    void Start()
    {
        lightButton.button.onClick.RemoveAllListeners();
        lightButton.button.onClick.AddListener(ChangeLight);
        lightButton.text = Strings.Light(world.isLight);
        morphButton.button.onClick.RemoveAllListeners();
        morphButton.button.onClick.AddListener(ChangeMorph);
        morphButton.text = Strings.Morph(world.isMorph);
        world.Apply();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeLight()
    {
        world.ChangeLight();
        lightButton.text = Strings.Light(world.isLight);
    }

    public void ChangeMorph()
    {
        world.ChangeMorph();
        morphButton.text = Strings.Morph(world.isMorph);
    }
}
