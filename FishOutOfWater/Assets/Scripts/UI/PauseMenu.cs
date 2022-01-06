using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public GameObject darkScreen;
    public GameObject firstButton;
    public GameObject pauseMenuUI;
    public bool GamePaused = false;
    public GameObject optionsButton;
    public GameObject optionsMenuUI;

    private Inputs inputs;

    private void Awake()
    {
        inputs = new Inputs();
        inputs.Enable();
    }

    private void Start()
    {
        ButtonSelected();
    }

    void Update()
    {
        if (inputs.Player.Pause.triggered)
        {
            if (GamePaused && pauseMenuUI.activeInHierarchy)
            {
                Resume();
            }
            else if(!optionsMenuUI.activeInHierarchy)
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        darkScreen.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        darkScreen.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void ButtonSelected()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }

    public void OptionsButton()
    {
        EventSystem.current.SetSelectedGameObject(optionsButton);
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