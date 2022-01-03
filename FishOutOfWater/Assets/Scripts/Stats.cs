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
        if(SceneManager.GetActiveScene().name == "1-tutorial" || SceneManager.GetActiveScene().name == "2-tutorial" || SceneManager.GetActiveScene().name == "3-Spike" || SceneManager.GetActiveScene().name == "4-Spike"
             || SceneManager.GetActiveScene().name == "5-Spike" || SceneManager.GetActiveScene().name == "6-spike" || SceneManager.GetActiveScene().name == "7-Spike" || SceneManager.GetActiveScene().name == "8-ToxicWater"
              || SceneManager.GetActiveScene().name == "9-ToxicWater" || SceneManager.GetActiveScene().name == "10-ToxicWater")
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
