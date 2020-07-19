﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour
{
    private float bgmMasterVolume = 1, sfxMasterVolume = 1;
    public AudioMixerGroup amg;
    
    public Dictionary<SoundClip, AudioSource> currentlyInitiatedSources;

    public void Play(SoundClip clip)
    {
        if (currentlyInitiatedSources.ContainsKey(clip))
        {
            PlayFromExisting(clip);
        }
        else
        {
            CreateSourceAndPlay(clip);
        }
    }

    void PlayFromExisting(SoundClip clip)
    {
        currentlyInitiatedSources[clip].Play();
    }

    void CreateSourceAndPlay(SoundClip clip)
    {
        CreateNewSource(clip);
        PlayFromExisting(clip);
    }

    public void Stop(SoundClip clip)
    {
        if (currentlyInitiatedSources.ContainsKey(clip))
        {
            currentlyInitiatedSources[clip].Stop();
        }
        else
        {
            Debug.LogWarning("No sound source was found using that clip");
        }
    }

    void CreateNewSource(SoundClip clip)
    {
        AudioSource newAs = gameObject.AddComponent<AudioSource>();
        newAs.clip = clip.file;
        newAs.volume = clip.volume;
        newAs.loop = clip.shouldLoop;
        newAs.outputAudioMixerGroup = amg;
        currentlyInitiatedSources.Add(clip, newAs);
    }
}
