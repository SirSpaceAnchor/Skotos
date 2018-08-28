using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float timer = 0f;
    public float Timed = 0f;
    // Use this for initialization
    void Start()
    {
        timer = 0f;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.PlayOneShot(audioClip);
        Timed = audioClip.length + 0.05f;
        Destroy(gameObject, Timed);
    }

    // Update is called once per frame
    void Update()
    {
        // Just keeping track, so we can see what the timed object is doing.
        timer += Time.deltaTime;
    }
}