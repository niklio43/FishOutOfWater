using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //private AudioSource audioSource;
    //private PauseMenu paused;

    public Sound[] sounds;

    void Awake()
    {
        foreach(Sound sound in sounds)
        {
            sound.audio = gameObject.AddComponent<AudioSource>();
            sound.audio.clip = sound.clip;
            sound.audio.volume = sound.volume;
        }

        //paused = FindObjectOfType<PauseMenu>();
    }

    void Update()
    {
        //Pause();
    }

    //public void Pause()
    //{
    //    if (paused.GamePaused)
    //    {
    //        audioSource.Pause();
    //    }
    //    else if (!paused.GamePaused)
    //    {
    //        audioSource.UnPause();
    //    }
    //}

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.audio.Play();
    }
}
