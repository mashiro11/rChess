using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXcontroller : MonoBehaviour
{
    private AudioSource aSourceSound;

    public AudioClip[] soundsArray;

    private void Start()
    {
        aSourceSound = GetComponent<AudioSource>();
    }

    public void PlaySound(int sound)
    {
        aSourceSound.clip = soundsArray[sound];
        aSourceSound.Play();
    }
}
