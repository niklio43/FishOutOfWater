using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointMaster cpm;

    private void Start()
    {
        cpm = GameObject.FindGameObjectWithTag("CPM").GetComponent<CheckpointMaster>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cpm.lastCPPos = transform.position;
        }
    }
}
