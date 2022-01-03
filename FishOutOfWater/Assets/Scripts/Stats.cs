using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public float timePlayed;
    public int deathCounter;

    private PauseMenu pauseMenu;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        pauseMenu = GameObject.Find("PauseCanvas").GetComponent<PauseMenu>();
        deathCounter = 0;
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name != "YouWin" && SceneManager.GetActiveScene().name != "Menu")
        {
            if (pauseMenu.GamePaused == false)
            {
                timePlayed += Time.deltaTime;
            }
        }
    }

    public void DeathIncrement()
    {
        deathCounter++;
    }
}
