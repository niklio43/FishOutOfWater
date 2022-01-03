using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private CheckpointMaster cpm;
    public int scene;

    private GameObject save;

    private Stats stats;

    private bool toggleSave;

    private void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Stats").GetComponent<Stats>();
        toggleSave = false;
        scene = 0;
        if (GameObject.FindGameObjectWithTag("CPM") != null)
            cpm = GameObject.FindGameObjectWithTag("CPM").GetComponent<CheckpointMaster>();
    }

    private void Update()
    {
        if (stats.playing && !toggleSave)
        {
            save = GameObject.FindGameObjectWithTag("Saving");
            save.SetActive(false);
            toggleSave = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cpm.lastCPPos = transform.position;
            scene = SceneManager.GetActiveScene().buildIndex;

            save.SetActive(true);
            Invoke("DisableGameObject", 1f);
        }
    }

    private void DisableGameObject()
    {
        save.SetActive(false);
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
