using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public bool GamePaused = false;
    public GameObject firstButton;

    private Inputs inputs;
    public GameObject pauseMenuUI;

    private void Awake()
    {
        inputs = new Inputs();
        inputs.Enable();
    }

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }

    void Update()
    {
        if (inputs.Player.Pause.triggered)
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
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