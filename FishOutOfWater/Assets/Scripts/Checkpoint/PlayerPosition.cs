using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private CheckpointMaster cpm;

    void Start()
    {
        cpm = GameObject.FindGameObjectWithTag("CPM").GetComponent<CheckpointMaster>();
        transform.position = cpm.lastCPPos;
    }
}
