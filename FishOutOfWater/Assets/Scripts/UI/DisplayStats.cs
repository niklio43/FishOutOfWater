using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayStats : MonoBehaviour
{
    public TextMeshProUGUI deathCounter, timePlayed;
    private Stats stats;

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Stats").GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        deathCounter.text = "Deaths: " + stats.deathCounter;
        timePlayed.text = "Time Played: " + stats.timePlayed;
    }
}
