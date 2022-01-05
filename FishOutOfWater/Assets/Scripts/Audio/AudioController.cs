using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    [HideInInspector]
    public float menuVolume;
    [HideInInspector]
    public bool invertedControls;
    public Sound[] sounds;

    private PauseMenu paused;
    private static AudioController instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;

        foreach (Sound sound in sounds) //Create array of all sounds
        {
            sound.audio = gameObject.AddComponent<AudioSource>();
            sound.audio.clip = sound.clip;
            sound.audio.volume = sound.volume;
            sound.audio.loop = sound.loop;
        }
        menuVolume = -1;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            Pause();
            if (sounds[8].audio.isPlaying)
            {
                sounds[8].audio.Stop();
            }
        }
    }

    public void Pause()
    {
        if (SceneManager.GetActiveScene().name == "1-tutorial" || SceneManager.GetActiveScene().name == "2-tutorial" || SceneManager.GetActiveScene().name == "3-Spike" || SceneManager.GetActiveScene().name == "4-Spike"
             || SceneManager.GetActiveScene().name == "5-Spike" || SceneManager.GetActiveScene().name == "6-spike" || SceneManager.GetActiveScene().name == "7-Spike" || SceneManager.GetActiveScene().name == "8-ToxicWater"
              || SceneManager.GetActiveScene().name == "9-ToxicWater" || SceneManager.GetActiveScene().name == "10-ToxicWater")
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

    public void MenuVolume(float volume)
    {
        foreach (Sound sound in sounds)
        {
            sound.audio.volume = sound.volume * volume;
        }
        menuVolume = volume;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "Menu" || scene.name != "YouWin")
        {
            paused = FindObjectOfType<PauseMenu>();
        }
    }

    public void InvertControl()
    {
        if (invertedControls == false)
            invertedControls = true;
        else if (invertedControls == true)
            invertedControls = false;
    }
}
