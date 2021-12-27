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
        }
        menuVolume = -1;
        invertedControls = false;
        Debug.Log(invertedControls);
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name != "Menu")
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
        if (scene.name != "Menu")
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
