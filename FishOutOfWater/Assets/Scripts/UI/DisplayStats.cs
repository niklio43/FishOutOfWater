using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DisplayStats : MonoBehaviour
{
    public TextMeshProUGUI deathCounter, timePlayed;
    private Stats stats;

    private void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Stats").GetComponent<Stats>();
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "LevelStats2.5")
        {
            var ts = TimeSpan.FromSeconds(stats.level1timePlayed);
            deathCounter.text = "" + stats.level1deathCounter;
            timePlayed.text = string.Format("{0:00}:{1:00}:{2:000}", ts.Minutes, ts.Seconds, ts.Milliseconds);
        }
        if (SceneManager.GetActiveScene().name == "LevelStats7.5")
        {
            var ts = TimeSpan.FromSeconds(stats.level2timePlayed);
            deathCounter.text = "" + stats.level2deathCounter;
            timePlayed.text = string.Format("{0:00}:{1:00}:{2:000}", ts.Minutes, ts.Seconds, ts.Milliseconds);
        }
        if (SceneManager.GetActiveScene().name == "LevelStats10.5")
        {
            var ts = TimeSpan.FromSeconds(stats.level3timePlayed);
            deathCounter.text = "" + stats.level3deathCounter;
            timePlayed.text = string.Format("{0:00}:{1:00}:{2:000}", ts.Minutes, ts.Seconds, ts.Milliseconds);
        }
        if (SceneManager.GetActiveScene().name == "YouWin")
        {
            var ts = TimeSpan.FromSeconds(stats.timePlayed);
            deathCounter.text = "" + stats.deathCounter;
            timePlayed.text = string.Format("{0:00}:{1:00}:{2:000}", ts.Minutes, ts.Seconds, ts.Milliseconds);
        }
    }
}
