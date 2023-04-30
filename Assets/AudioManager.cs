using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioClip crashClip;
    [SerializeField] private AudioClip failureClip;
    [SerializeField] private AudioClip successClip;
    [SerializeField] private AudioClip throwClip;
    [SerializeField] private AudioClip clickClip;
    [SerializeField] private AudioClip zoomClip;

    private AudioSource audioSource;

    private void Start()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayThrowClip()
    {
        PlayClip(throwClip);
    }

    public void PlayCrashClip()
    {
        PlayClip(crashClip);
    }


    public void PlaySuccessClip()
    {
        PlayClip(successClip);
    }

    public void PlayFailureClip()
    {
        PlayClip(failureClip);
    }

    public  void PlayClickClip()
    {
        PlayClip(clickClip);
    }

    public void PlayZoomClip()
    {
        PlayClip(zoomClip);
    }

    private void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
