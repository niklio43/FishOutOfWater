using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

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
        var ts = TimeSpan.FromSeconds(stats.timePlayed);

        deathCounter.text = "Deaths: " + stats.deathCounter;
        timePlayed.text = "Time Played: " + string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
    }
}
