using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.loop = s.looped;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(string name){
        Sound s = Array.Find(sounds, s => s.name == name);
        s.audioSource.Play();
    }

    public void Stop(string name){
        Sound s = Array.Find(sounds, s => s.name == name);
        s.audioSource.Stop();
    }

    public void Pause(string name){
        Sound s = Array.Find(sounds, s => s.name == name);
        s.audioSource.Pause();
    }

}
