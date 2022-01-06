using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfScene : MonoBehaviour
{
    private CheckpointMaster cpm;

    private void Start()
    {
        if(GameObject.FindGameObjectWithTag("CPM") != null)
            cpm = GameObject.FindGameObjectWithTag("CPM").GetComponent<CheckpointMaster>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(cpm != null)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
