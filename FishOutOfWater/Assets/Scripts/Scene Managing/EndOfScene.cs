using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfScene : MonoBehaviour
{
    private CheckpointMaster cpm;

    private void Start()
    {
        cpm = GameObject.FindGameObjectWithTag("CPM").GetComponent<CheckpointMaster>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cpm.lastCPPos = new Vector2(-7.183609f, -4.734975f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
