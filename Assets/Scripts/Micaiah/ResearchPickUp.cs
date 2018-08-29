using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResearchPickUp : MonoBehaviour
{
    public AudioClip clip;
    public string AudioClipDesignation;
    public TMP_Text textObject;

    private void Awake()
    {
        World.OnLightChanged += LightChanged;
        LightChanged(true);
        textObject.text = "Research" + "\n" + "Note: " + AudioClipDesignation;
    }

    void LightChanged(bool isLight)
    {
        gameObject.SetActive(!isLight);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            transform.Rotate(Vector3.up, 5f);
        }
    }
}
