using UnityEngine;

public class PlayCutsceneSound : MonoBehaviour
{
    public string clipName;

    private AudioController sound;
    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioController>();
        sound.Play(clipName);
    }

    
}
