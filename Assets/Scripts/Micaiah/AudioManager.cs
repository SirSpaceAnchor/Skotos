using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusType { WakeUp, Pickup, DoorError, GunPew };

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSound audioSoundPrefab;
    public Transform AudioTransform;

    public AudioClip[] pickupClips;
    public AudioClip[] combatClips;
    public AudioClip[] calloutClips;

    [Header("Random List")]
    public AudioClip[] gunPews;

    [Header("Ordered List")]
    public AudioClip[] doorErrors;

    int callOutIndex = 0;
    int gunSwitchIndex = 0;
    int doorErrorIndex = 0;

    public void Init()
    {
        AudioTransform = new GameObject("Audio").transform;
        AudioTransform.SetParent(this.transform);
    }

    public bool Play(AudioClip clip)
    {
        if (CreateSound(clip.name, clip))
        {
            return true;
        }
        return false;
    }

    public void Play(StatusType type)
    {
        if (type == StatusType.DoorError)
        {
            if (CreateSound(type.ToString() + "-" + doorErrorIndex.ToString(), doorErrors[doorErrorIndex]))
            {
                doorErrorIndex++;
                if (doorErrorIndex >= doorErrors.Length - 1)
                {
                    doorErrorIndex = doorErrors.Length - 1;
                }
            }
        }
        if (type == StatusType.GunPew)
        {
            int r = Random.Range(0, gunPews.Length);
            if (CreateSound(type.ToString() + "-" + r.ToString(), gunPews[r]))
            {
            }
        }
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