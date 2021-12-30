using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private CheckpointMaster cpm;
    public int scene;

    private void Start()
    {
        scene = 0;
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
        SceneManager.LoadScene(scene);
    }
}
