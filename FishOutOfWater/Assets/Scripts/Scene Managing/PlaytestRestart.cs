using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlaytestRestart : MonoBehaviour
{
    public string sceneName;

    private Inputs inputs;

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        inputs = new Inputs();
        inputs.Enable();
    }

    void Update()
    {
        if (inputs.Player.Restart.triggered)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
