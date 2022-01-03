using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject firstButton, optionsButton, creditsButton;

    private Stats stats;

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

        stats.totalTimePlayed += stats.timePlayed;
        stats.totalDeathCounter += stats.deathCounter;

        stats.timePlayed = 0f;
        stats.deathCounter = 0;

        SceneManager.LoadScene(nextScene);
    }

    public void PlayAgain()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
            stats.timePlayed = 0;

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
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
    #else
             Application.Quit();
    #endif
    }
}
