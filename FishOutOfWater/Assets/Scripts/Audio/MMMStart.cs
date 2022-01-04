using UnityEngine;

public class MMMStart : MonoBehaviour
{
    private AudioController sound;

    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioController>();
        PlayMusic();
    }

    private void PlayMusic()
    {
        foreach (Sound sound in sound.sounds)
        {
            sound.audio.Pause();
        }
        sound.GetComponent<AudioController>().Play("Main Menu Music");
    }
}
