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
        if(SceneManager.GetActiveScene().name != "YouWin")
        {
            var ts = TimeSpan.FromSeconds(stats.levelTime);
            deathCounter.text = "" + stats.levelDeathCounter;
            timePlayed.text = string.Format("{0:00}:{1:00}:{2:000}", ts.Minutes, ts.Seconds, ts.Milliseconds);
        }
        else
        {
            var ts = TimeSpan.FromSeconds(stats.timePlayed);
            deathCounter.text = "" + stats.deathCounter;
            timePlayed.text = string.Format("{0:00}:{1:00}:{2:000}", ts.Minutes, ts.Seconds, ts.Milliseconds);
        }
    }
}
