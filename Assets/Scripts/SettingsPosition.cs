using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingsPosition : Settings
{
    //NOT our start position, but our offset from our parent.
    public Vector3 startPosition;
    public Vector3 startRotation;

    public Vector3 morphPosition = Vector3.zero;
    public Vector3 morphRotation = Vector3.zero;

    public Vector3 desiredPosition;
    public Vector3 desiredRotation;

    public bool isMorphCurrent = true; // true; we are in our smallest default morph

    public SettingsPosition(Vector3 offset, Vector3 startEuler)
    {
        startPosition = offset;
        startRotation = startEuler;
    }

    public override void MorphSwitch(bool newMorph)
    {
        base.MorphSwitch(newMorph);
        if (allowMorph)
        {
            if (isMorphCurrent)
            {
                desiredPosition = morphPosition;
                desiredRotation = morphRotation;
            }
            else
            {
                desiredPosition = startPosition;
                desiredRotation = startRotation;
            }
            //cubes[i].isFormed = !cubes[i].isFormed;
            //if (isFormed)
            //{
            //    cubes[i].transform.eulerAngles = cubes[i].cube.startRotation;
            //    Vector3 movePosition = transform.position - cubes[i].transform.position;
            //    //cubes[i].transform.position = movePosition * 0.1f;
            //    cubes[i].transform.Translate(movePosition * speed);
            //    //cubes[i].transform.rotation = defaultStart.rotation;
            //    if (Vector3.Distance(cubes[i].transform.position, defaultStart.position) >= 0.1f)
            //    {
            //        isDone = false;
            //    }
            //}
            //else
            //{
            //    cubes[i].transform.eulerAngles = cubes[i].cube.startRotation;
            //    Vector3 movePosition = cubes[i].cube.startPosition - transform.position;
            //    //cubes[i].transform.position = movePosition * 0.1f;
            //    cubes[i].transform.Translate(movePosition * 0.01f);
            //    //cubes[i].transform.rotation = defaultStart.rotation;
            //    if (Vector3.Distance(cubes[i].transform.position, cubes[i].cube.startPosition) >= 0.01f)
            //    {
            //        isDone = false;
            //    }
            //}
        }

    }

}
