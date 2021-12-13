using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaytestRestart : MonoBehaviour
{
    public string sceneName;

    private DisplayAmmo displayAmmo;

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(sceneName);
            displayAmmo = GameObject.FindGameObjectWithTag("Player").GetComponent<DisplayAmmo>();
            displayAmmo.CreateAmmoAroundPoint();
        }
    }
}
