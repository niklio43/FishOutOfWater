using UnityEngine;

public class NetTrigger : MonoBehaviour
{
    public bool throwing;
    public Vector3 targetPos;
    public GameObject fishNet;

    private GameObject Player;
    private FishNetDolphin fishNetDolphin;

    private void Start()
    {
        throwing = false;
        fishNetDolphin = transform.GetComponentInParent<FishNetDolphin>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (throwing)
        {
            GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            GetComponent<Collider2D>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !fishNetDolphin.dead && Player != null)
        {
            throwing = true;
            targetPos = new Vector3(Player.transform.position.x, Player.transform.position.y + 5, Player.transform.position.z);

            Invoke("ToggleThrow", 1);
        }
    }

    private void ToggleThrow()
    {
        throwing = false;
    }
}
