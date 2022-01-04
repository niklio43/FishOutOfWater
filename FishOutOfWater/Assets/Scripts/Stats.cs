using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public float timePlayed, totalTimePlayed;
    public int deathCounter, totalDeathCounter;
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
                Debug.Log("Time: " + timePlayed);
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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "1-tutorial" || scene.name == "2-tutorial" || scene.name == "3-Spike" || scene.name == "4-Spike"
             || scene.name == "5-Spike" || scene.name == "6-spike" || scene.name == "7-spike" || scene.name == "8-ToxicWater"
              || scene.name == "9-Toxicwater" || scene.name == "10-ToxicWater" || scene.name == "11-Moving-platform" || scene.name == "12-Moving-platform"
               || scene.name == "13-Moving-platform" || scene.name == "14-Moving-platform")
        {
            totalTimePlayed += timePlayed;
            totalDeathCounter += deathCounter;

            deathCounter = 0;
        }
    }
}
