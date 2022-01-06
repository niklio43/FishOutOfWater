using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointMaster : MonoBehaviour
{
    public Vector2 lastCPPos;
    private string sceneName;

    private static CheckpointMaster instance;
    private GameObject player;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        SceneManager.sceneLoaded += OnSceneLoaded;
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name != sceneName)
        {
            player = GameObject.FindWithTag("Player");
            if(player != null)
                lastCPPos = player.transform.position;
            sceneName = scene.name;
        }
    }
}
