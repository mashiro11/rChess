using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    //public static MusicController musicController = null;

    private AudioSource aSourceMusic;
    public AudioClip[] musicArray;

    public float volume = 0.4f;
    private bool looping = false;

    private void Awake()
    {
        aSourceMusic = GetComponent<AudioSource>();

        aSourceMusic.volume = volume;
        aSourceMusic.clip = musicArray[0];
        aSourceMusic.loop = false;
        aSourceMusic.Play();
    }

    private void Update()
    {
        aSourceMusic.volume = volume;
        if (looping == false && aSourceMusic.isPlaying == false)
        {
            looping = true;
            aSourceMusic.clip = musicArray[1];
            aSourceMusic.loop = true;
            aSourceMusic.Play();
        }
    }
}
