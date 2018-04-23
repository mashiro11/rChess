﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public AudioClip[] musicArray;
    private bool looping = false;
    AudioSource aSource;
    float volume = 0.4f;

    private void Awake()
    {
        aSource = GetComponent<AudioSource>();

        aSource.volume = volume;
        aSource.clip = musicArray[0];
        aSource.loop = false;
        aSource.Play();
    }

    private void Update()
    {
        aSource.volume = volume;
        if (looping == false && aSource.isPlaying == false)
        {
            looping = true;
            aSource.clip = musicArray[1];
            aSource.loop = true;
            aSource.Play();
        }
    }


}