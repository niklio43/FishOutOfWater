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
            var ts = TimeSpan.FromSeconds(stats.timePlayed);
            deathCounter.text = "" + stats.deathCounter;
            timePlayed.text = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
        }
        else
        {
            var ts = TimeSpan.FromSeconds(stats.totalTimePlayed);
            deathCounter.text = "" + stats.totalDeathCounter;
            timePlayed.text = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
        }
    }
}
