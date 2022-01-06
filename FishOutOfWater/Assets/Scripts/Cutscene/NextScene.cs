using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public int clipIndex;
    public GameObject text;

    private Inputs input;
    private AudioController sound;


    void Start()
    {
        input = new Inputs();
        input.Enable();
        sound = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioController>();
        Invoke("ContinueText", 2);
    }

    void Update()
    {
        if (input.Player.Skip.triggered)
        {
            sound.sounds[clipIndex].audio.Pause();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void ContinueText()
    {
        text.SetActive(true);
    }
}
