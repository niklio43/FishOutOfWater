using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    Inputs input;

    void Start()
    {
        input = new Inputs();
        input.Enable();
    }

    void Update()
    {
        if (input.Player.Skip.triggered)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
