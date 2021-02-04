using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Music : MonoBehaviour
{
    [SerializeField]
    private AudioSource music;
    [SerializeField]
    private AudioMixerSnapshot fadeInSnapshot;
    [SerializeField]
    private float fadeInTime = 10;
    private void Start()
    {
        fadeInSnapshot.TransitionTo(fadeInTime);
        music.Play();
        music.loop = true;
    }
    
    private void OnDestroy()
    {
        music.Stop();
    }
}
