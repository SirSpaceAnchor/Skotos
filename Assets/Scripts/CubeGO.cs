using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SettingsPosition?

public class CubeGO : MonoBehaviour
{
    public Cube cube;
    public bool isMorphed = true;
    private bool formedLast;

    private void Awake()
    {
    }

    /// <summary>
    /// Function to be called by the parent to set its starting location
    /// Did this; so other scripts can run first, such as CubeShape
    /// </summary>
    public void Register()
    {
        //cube = ScriptableObject.CreateInstance<Cube>();
        cube = new Cube(this.transform.position, this.transform.eulerAngles, true, 1.0f);
        cube.SetStart(GetComponentInChildren<MeshRenderer>());
    }

    // Use this for initialization
    void Start()
    {
        //SwitchMorph();
    }

    // Update is called once per frame
    void Update()
    {
        //if (cube.currentColor != cube.desiredColor)
        {
            cube.material.color = Color.Lerp(cube.material.color, cube.colorSettings.desiredColor, 0.1f);
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * cube.scaleSettings.desiredScale, 0.1f);
            transform.position = Vector3.Lerp(transform.position, cube.positionSettings.desiredPosition, 0.1f);
            transform.eulerAngles = Vector3.Lerp(transform.position, cube.positionSettings.desiredRotation, 0.1f);
            //cube.currentColor = cube.material.color;
        }
        //else
        {
            //UnityEngine.Debug.Log("Met color requirements");
            //cube.currentColor = cube.desiredColor;
        }
    }

    public void SwitchMorph(bool isMorph)
    {
        isMorphed = isMorph;
        cube.positionSettings.MorphSwitch(isMorphed);
    }
}
