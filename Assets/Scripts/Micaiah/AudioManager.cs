using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings
{
    public static bool PlayMultipleClips = true;
}

public enum StatusType { WakeUp, Pickup, SwitchGun };

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSound audioSoundPrefab;
    public Transform AudioTransform;

    public AudioClip[] pickupClips;
    public AudioClip[] combatClips;
    public AudioClip[] calloutClips;
    public AudioClip[] gunSwiches;

    int callOutIndex = 0;
    int gunSwitchIndex = 0;

    private void Awake()
    {
        instance = this;
        AudioTransform = new GameObject("Audio").transform;
        AudioTransform.SetParent(this.transform);
    }

    public void Play(string dialogue, bool isPlayer)
    {
        UnityEngine.Debug.Log("Sound Play?: " + dialogue);
        foreach (StatusType type in System.Enum.GetValues(typeof(StatusType)))
        {
            if (dialogue == type.ToString())
            {
                if (type == StatusType.WakeUp)
                {
                    if (callOutIndex >= calloutClips.Length)
                    {
                        callOutIndex = 0;
                    }
                    if (CreateSound(type.ToString(), calloutClips[callOutIndex]))
                    {
                        callOutIndex++;
                        if (callOutIndex >= calloutClips.Length)
                        {
                            callOutIndex = 0;
                        }
                    }
                }
                if (type == StatusType.SwitchGun)
                {
                    if (CreateSound(type.ToString(), gunSwiches[gunSwitchIndex]))
                    {
                        gunSwitchIndex++;
                        if (gunSwitchIndex >= gunSwiches.Length)
                        {
                            gunSwitchIndex = 0;
                        }
                    }
                }
            }
        }
    }

    bool CreateSound(string sound, AudioClip clip)
    {
        if (AudioTransform.childCount == 0 || GameSettings.PlayMultipleClips)
        {
            UnityEngine.Debug.Log("Sound Play: " + sound);
            AudioSound aSound = GameObject.Instantiate(audioSoundPrefab);
            aSound.transform.SetParent(AudioTransform);
            aSound.audioClip = clip;
            return true;
        }
        return false;
    }

    //// Use this for initialization
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}