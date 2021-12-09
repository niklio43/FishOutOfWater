using UnityEngine;

public class BGMStart : MonoBehaviour
{
    private GameObject sound;

    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("AudioManager");
        sound.GetComponent<AudioController>().Play("Background Music");
    }
}
