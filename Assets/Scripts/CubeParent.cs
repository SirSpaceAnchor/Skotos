using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://github.com/SirSpaceAnchor/Skotos

// Phos - Light (Knowledge)
// Skotos - Dark

// One problem, is we have a good way to switch
// BUT not way to switch Size easily

// ALSO really one trigger is up and down

// We have no direct setup of our children.

// IN The process of changing things over, VERY much in flux, such as morph on a button
// PROB will leave it as is (comments go from top to bottom, by subject)

public class CubeParent : MonoBehaviour
{
    // Switch this to CubeSO
    public CubeGO[] cubes;
    public Transform defaultStart;

    public bool isMorphed = true;
    public bool morphTrigger = false;

    public float delay = 0.5f;
    public float speed = 0.1f;

    private bool lightCurrent;
    public bool isLightCurrent;

    // Use this for initialization
    void Start()
    {
        cubes = GetComponentsInChildren<CubeGO>();
        for (int i = 0; i < cubes.Length; i++)
        {
            isLightCurrent = cubes[i].cube.lightSettings.isLightCurrent;
            cubes[i].transform.position = defaultStart.position;
            cubes[i].transform.rotation = defaultStart.rotation;
            cubes[i].transform.localScale = Vector3.zero;
        }
        //isMorphed = true;
        //morphTrigger = true;
        lightCurrent = isLightCurrent;

        World.OnLightChanged += LightChanged;
        World.OnMorphChanged += MorphChanged;
    }

    void MorphChanged(bool newMorph)
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].SwitchMorph();
            //if (cubes[i].cube.allowSwitch)
            //{
            //    //cubes[i].cube.isLightCurrent = newLight;
            //}
        }

        //for (int i = 0; i < cubes.Length; i++)
        //{
        //    cubes[i].SwitchMorph();
        //}
        //formTimer = 0f;
        ////StartCoroutine(Forming());
    }

    void LightChanged(bool newLight)
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].cube.Switch();
            //if (cubes[i].cube.allowSwitch)
            //{
            //    //cubes[i].cube.isLightCurrent = newLight;
            //}
        }
    }

    [SerializeField] float startTime = 0f;
    [SerializeField] float formTimer = 0f;

    [SerializeField] float startDeformTime = 0f;
    [SerializeField] float deformTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            morphTrigger = true;
        }
        if (morphTrigger)
        {
            morphTrigger = false;
            MorphChanged(isMorphed);
        }
        if (lightCurrent != isLightCurrent)
        {
            lightCurrent = isLightCurrent;
            LightChange();
        }
    }

    void LightChange()
    {
        UnityEngine.Debug.Log("Switch from " + Strings.Light(isLightCurrent) + " to " + Strings.LightOpposite(isLightCurrent));
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].cube.Switch();
        }
    }
}

/* Hidden
//void Form()
//{
//    //if (formTrigger)
//    //{
//    //    startTime = Time.time;
//    //    formTrigger = false;
//    //}

//    formTimer += Time.deltaTime;
//    if (formTimer <= 1)
//    {
//        for (int i = 0; i < cubes.Length; i++)
//        {
//            if (isFormed)
//            {
//                cubes[i].transform.eulerAngles = cubes[i].cube.startRotation;
//                Vector3 movePosition = defaultStart.position - cubes[i].transform.position;
//                //cubes[i].transform.position = movePosition * 0.1f;
//                cubes[i].transform.Translate(movePosition * 0.01f);
//                //cubes[i].transform.rotation = defaultStart.rotation;
//            }
//            else
//            {
//                cubes[i].transform.eulerAngles = cubes[i].cube.startRotation;
//                Vector3 movePosition = cubes[i].cube.startPosition - defaultStart.position;
//                //cubes[i].transform.position = movePosition * 0.1f;
//                cubes[i].transform.Translate(movePosition * 0.01f);
//                //cubes[i].transform.rotation = defaultStart.rotation;
//            }
//        }
//    }
//    else
//    {
//        isFormed = true;
//    }
//}
*/

/* Forming IEnumerator
IEnumerator Forming()
{
    bool isDone = false;
    UnityEngine.Debug.Log("Forming...");
    //while (formTimer <= 1 && isDone)
    while (isDone == false)
    {
        isDone = true;
        for (int i = 0; i < cubes.Length; i++)
        {
            if (isFormed)
            {
                cubes[i].transform.eulerAngles = cubes[i].cube.startRotation;
                Vector3 movePosition = transform.position - cubes[i].transform.position;
                //cubes[i].transform.position = movePosition * 0.1f;
                cubes[i].transform.Translate(movePosition * speed);
                //cubes[i].transform.rotation = defaultStart.rotation;
                if (Vector3.Distance(cubes[i].transform.position, defaultStart.position) >= 0.1f)
                {
                    isDone = false;
                }
            }
            else
            {
                cubes[i].transform.eulerAngles = cubes[i].cube.startRotation;
                Vector3 movePosition = cubes[i].cube.startPosition - transform.position;
                //cubes[i].transform.position = movePosition * 0.1f;
                cubes[i].transform.Translate(movePosition * 0.01f);
                //cubes[i].transform.rotation = defaultStart.rotation;
                if (Vector3.Distance(cubes[i].transform.position, cubes[i].cube.startPosition) >= 0.01f)
                {
                    isDone = false;
                }
            }
        }
            
        formTimer += 0.01f;
        yield return new WaitForSeconds(delay);
    }
    isFormed = !isFormed;
    yield return null;
}
*/
