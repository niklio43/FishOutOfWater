using UnityEngine;

public class MMMStart : MonoBehaviour
{
    private GameObject sound;

    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("AudioManager");
        sound.GetComponent<AudioController>().Play("Main Menu Music");
    }
}
