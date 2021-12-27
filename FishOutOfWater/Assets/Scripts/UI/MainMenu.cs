using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject firstButton, optionsButton, creditsButton;

    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayAgain()
    {
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
