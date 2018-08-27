using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif

public class CountdownTimer : MonoBehaviour
{
    public ButtonGO buttonGO;
    public DateTime launchDate;
    string TimeToFinish = "September 1 2018 12:00 AM";
    public string countDown;

    public bool isRunning = false;

    private void OnValidate()
    {
        if (buttonGO == null)
        {
            buttonGO = GetComponent<ButtonGO>();
        }
        DateTime.TryParse(TimeToFinish, out launchDate);
        //UnityEngine.Debug.Log(launchDate.ToString());
        if (isRunning == false)
        {
            isRunning = true;
            StartCoroutine(TickTimer());
        }
    }

    void Tick()
    {
        //UnityEngine.Debug.Log("Timing.");
        //Calculate countdown timer.
        TimeSpan t = launchDate.Subtract(DateTime.Now);
        //TimeSpan t = DateTime.Now - timeToFinish;
        countDown = string.Format("{0} Days, {1} Hours, {2} Minutes, {3} Seconds til launch.", t.Days, t.Hours, t.Minutes, t.Seconds);
#if UNITY_EDITOR
        buttonGO.text = countDown;
#else
        buttonGO.text = "";
#endif
    }

    IEnumerator TickTimer()
    {
        while (isRunning)
        {
            Tick();
            yield return new WaitForSeconds(1f);
        }
    }

    //// Use this for initialization
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        Tick(); 
    }
}
