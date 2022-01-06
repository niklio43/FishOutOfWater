using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject firstButton, optionsButton, creditsButton;

    private Stats stats;
    private GameObject lastButton;
    private AudioController sound;

    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);
        if (SceneManager.GetActiveScene().name != "Menu")
            stats = GameObject.FindGameObjectWithTag("Stats").GetComponent<Stats>();

        sound = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioController>();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadNextScene()
    {
        var nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void PlayAgain()
    {
        if (SceneManager.GetActiveScene().name != "Menu")

            sound.sounds[0].audio.Stop();

        SceneManager.LoadScene("Menu");
    }

    public void OpenOptions()
    {
        EventSystem.current.SetSelectedGameObject(optionsButton);
    }

    public void OpenCredits()
    {
        EventSystem.current.SetSelectedGameObject(creditsButton);
    }

    public void ClosingMenu()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }

    public void QuitGame()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
             Application.Quit();
    #endif
    }
}
