using System;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public Sound[] sounds;

    private PauseMenu paused;

    void Awake()
    {
        foreach(Sound sound in sounds) //Create array of all sounds
        {
            sound.audio = gameObject.AddComponent<AudioSource>();
            sound.audio.clip = sound.clip;
            sound.audio.volume = sound.volume;
        }

        paused = FindObjectOfType<PauseMenu>();
    }

    void Update()
    {
            Pause();
    }

    public void Pause()
    {
        if (paused.GamePaused)
        {
            sounds[0].audio.Pause(); //Pause the background music
        }
        else if (!paused.GamePaused)
        {
            sounds[0].audio.UnPause();
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.audio.Play();
    }

    public void PlayOnce(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.audio.PlayOneShot(s.clip);
    }
}
