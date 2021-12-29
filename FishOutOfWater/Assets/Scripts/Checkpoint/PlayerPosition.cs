using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private CheckpointMaster cpm;

    void Start()
    {
        if(GameObject.FindGameObjectWithTag("CPM") != null)
        {
            cpm = GameObject.FindGameObjectWithTag("CPM").GetComponent<CheckpointMaster>();
            transform.position = cpm.lastCPPos;
        }
    }
}
