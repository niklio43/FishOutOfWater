using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public float timePlayed;
    public int deathCounter;
    public bool playing;

    private PauseMenu pauseMenu;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        pauseMenu = GameObject.Find("PauseCanvas").GetComponent<PauseMenu>();
        deathCounter = 0;
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name != "YouWin" && SceneManager.GetActiveScene().name != "Menu" && SceneManager.GetActiveScene().name != "Epilogue-1" && SceneManager.GetActiveScene().name != "Epilogue-2" && SceneManager.GetActiveScene().name != "Prologue-1"
             && SceneManager.GetActiveScene().name != "Prologue-2-1" && SceneManager.GetActiveScene().name != "Prologue-2-2")
        {
            if (pauseMenu.GamePaused == false)
            {
                playing = true;
                timePlayed += Time.deltaTime;
            }
            else
            {
                playing = false;
            }
        }
        else
        {
            playing = false;
        }
    }

    public void DeathIncrement()
    {
        deathCounter++;
    }
}
