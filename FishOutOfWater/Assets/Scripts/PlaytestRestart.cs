using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaytestRestart : MonoBehaviour
{
    string sceneName;

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
