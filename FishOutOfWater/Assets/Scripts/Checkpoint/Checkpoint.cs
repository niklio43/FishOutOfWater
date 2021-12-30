using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private CheckpointMaster cpm;
    public int scene, deathCounter;
    public float timePlayed;
    //private PlayerController playerController;

    private void Start()
    {
        //playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        scene = 0;
        timePlayed = 0f;
        if (GameObject.FindGameObjectWithTag("CPM") != null)
            cpm = GameObject.FindGameObjectWithTag("CPM").GetComponent<CheckpointMaster>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cpm.lastCPPos = transform.position;
            scene = SceneManager.GetActiveScene().buildIndex;
        }
    }

    public void Save()
    {
        SaveData.Save(this);
    }

    public void Load()
    {
        GameData data = SaveData.Load();
        scene = data.scene;
        //deathCounter = playerController.deathCounter;
        timePlayed = data.timePlayed;
        SceneManager.LoadScene(scene);
    }

    /*public void LoadStats()
    {
        GameData data = SaveData.Load();
        scene = data.scene;
        deathCounter = playerController.deathCounter;
        timePlayed = data.timePlayed;
    }*/
}
