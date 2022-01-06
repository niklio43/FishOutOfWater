using UnityEngine;

public class ResumeMusic : MonoBehaviour
{
    private AudioController sound;

    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioController>();
    }

    public void StartMusic()
    {
        sound.Play("Background Music");
    }
}
