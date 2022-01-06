using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public float timePlayed, level1timePlayed, level2timePlayed, level3timePlayed;
    public int deathCounter, level1deathCounter, level2deathCounter, level3deathCounter;
    public bool playing;
    private static Stats instance;

    private PauseMenu pauseMenu;
    void Awake()
    {
        deathCounter = level1deathCounter = level2deathCounter = level3deathCounter = 0;
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "1-tutorial" || SceneManager.GetActiveScene().name == "2-tutorial" || SceneManager.GetActiveScene().name == "3-Spike" || SceneManager.GetActiveScene().name == "4-Spike"
             || SceneManager.GetActiveScene().name == "5-Spike" || SceneManager.GetActiveScene().name == "6-spike" || SceneManager.GetActiveScene().name == "7-spike" || SceneManager.GetActiveScene().name == "8-ToxicWater"
              || SceneManager.GetActiveScene().name == "9-Toxicwater" || SceneManager.GetActiveScene().name == "10-ToxicWater" || SceneManager.GetActiveScene().name == "11-Moving-platform" || SceneManager.GetActiveScene().name == "12-Moving-platform"
               || SceneManager.GetActiveScene().name == "13-Moving-platform" || SceneManager.GetActiveScene().name == "14-Moving-platform")
        {
            if (pauseMenu.GamePaused == false)
            {
                playing = true;
                timePlayed += Time.deltaTime;
                Cursor.visible = false;

                if (SceneManager.GetActiveScene().name == "1-tutorial" || SceneManager.GetActiveScene().name == "2-tutorial")
                {
                    level1timePlayed += Time.deltaTime;
                }
                if (SceneManager.GetActiveScene().name == "3-Spike" || SceneManager.GetActiveScene().name == "4-Spike"
             || SceneManager.GetActiveScene().name == "5-Spike" || SceneManager.GetActiveScene().name == "6-spike" || SceneManager.GetActiveScene().name == "7-spike")
                {
                    level2timePlayed += Time.deltaTime;
                }
                if (SceneManager.GetActiveScene().name == "8-ToxicWater"
              || SceneManager.GetActiveScene().name == "9-Toxicwater" || SceneManager.GetActiveScene().name == "10-ToxicWater")
                {
                    level3timePlayed += Time.deltaTime;
                }
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
        if (SceneManager.GetActiveScene().name == "1-tutorial" || SceneManager.GetActiveScene().name == "2-tutorial" || SceneManager.GetActiveScene().name == "3-Spike" || SceneManager.GetActiveScene().name == "4-Spike"
     || SceneManager.GetActiveScene().name == "5-Spike" || SceneManager.GetActiveScene().name == "6-spike" || SceneManager.GetActiveScene().name == "7-spike" || SceneManager.GetActiveScene().name == "8-ToxicWater"
      || SceneManager.GetActiveScene().name == "9-Toxicwater" || SceneManager.GetActiveScene().name == "10-ToxicWater" || SceneManager.GetActiveScene().name == "11-Moving-platform" || SceneManager.GetActiveScene().name == "12-Moving-platform"
       || SceneManager.GetActiveScene().name == "13-Moving-platform" || SceneManager.GetActiveScene().name == "14-Moving-platform")
        {
            deathCounter++;
            if (SceneManager.GetActiveScene().name == "1-tutorial" || SceneManager.GetActiveScene().name == "2-tutorial")
            {
                level1deathCounter++;
            }
            if (SceneManager.GetActiveScene().name == "3-Spike" || SceneManager.GetActiveScene().name == "4-Spike"
         || SceneManager.GetActiveScene().name == "5-Spike" || SceneManager.GetActiveScene().name == "6-spike" || SceneManager.GetActiveScene().name == "7-spike")
            {
                level2deathCounter++;
            }
            if (SceneManager.GetActiveScene().name == "8-ToxicWater"
          || SceneManager.GetActiveScene().name == "9-Toxicwater" || SceneManager.GetActiveScene().name == "10-ToxicWater")
            {
                level3deathCounter++;
            }
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "LevelStats2.5" || scene.name == "LevelStats7.5" || scene.name == "LevelStats10.5" || scene.name == "Menu" || scene.name == "YouWin")
        {
            Cursor.visible = true;
        }
        if(scene.name == "1-tutorial")
        {
            pauseMenu = GameObject.Find("PauseCanvas").GetComponent<PauseMenu>();
        }
    }
}
