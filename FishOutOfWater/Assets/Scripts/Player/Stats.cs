using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float timePlayed;
    public int deathCounter;

    void Start()
    {
        timePlayed = 0f;
        deathCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timePlayed += Time.deltaTime;
    }
}
