using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public float timePlayed, levelTime, combinedLevelTime;
    public int deathCounter, levelDeathCounter;
    public bool playing;

    private PauseMenu pauseMenu;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        pauseMenu = GameObject.Find("PauseCanvas").GetComponent<PauseMenu>();
        deathCounter = 0;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "1-tutorial" || SceneManager.GetActiveScene().name == "2-tutorial" || SceneManager.GetActiveScene().name == "3-Spike" || SceneManager.GetActiveScene().name == "4-Spike"
             || SceneManager.GetActiveScene().name == "5-Spike" || SceneManager.GetActiveScene().name == "6-spike" || SceneManager.GetActiveScene().name == "7-spike" || SceneManager.GetActiveScene().name == "8-ToxicWater"
              || SceneManager.GetActiveScene().name == "9-Toxicwater" || SceneManager.GetActiveScene().name == "10-ToxicWater" || SceneManager.GetActiveScene().name == "11-Moving-platform" || SceneManager.GetActiveScene().name == "12-Moving-platform"
               || SceneManager.GetActiveScene().name == "13-Moving-platform" || SceneManager.GetActiveScene().name == "14-Moving-platform")
        {
            if (pauseMenu.GamePaused == false)
            {
                playing = true;
                timePlayed += Time.deltaTime;
                Cursor.visible = false;
            }
            else
            {
                playing = false;
                Cursor.visible = true;
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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "LevelStats2.5" || scene.name == "LevelStats7.5" || scene.name == "LevelStats10.5")
        {
            levelDeathCounter = deathCounter - levelDeathCounter;
            levelTime = timePlayed - combinedLevelTime;
            combinedLevelTime = timePlayed;
            Cursor.visible = true;
        }
        if(scene.name == "Menu" || scene.name == "YouWin")
        {
            Cursor.visible = true;
        }
    }
}
