using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetToStart : MonoBehaviour
{
    string sceneName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Amelie");
        }
    }
}
