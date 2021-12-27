using UnityEngine;

public class FishNetController : MonoBehaviour
{
    public bool caughtByFishNet;

    private GameObject Player;
    private NetTrigger netTrigger;

    private void Start()
    {
        caughtByFishNet = false;
        netTrigger = GameObject.FindGameObjectWithTag("netTrigger").GetComponent<NetTrigger>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreLayerCollision(9, 8, true);
        Physics2D.IgnoreLayerCollision(11, 8, true);
        Physics2D.IgnoreLayerCollision(12, 8, true);
    }

    private void Update()
    {
        if (!netTrigger.throwing)
        {
            caughtByFishNet = false;
        }

        if (caughtByFishNet)
        {
            Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            caughtByFishNet = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && caughtByFishNet && GameObject.FindGameObjectWithTag("PlayerBottom").GetComponent<GroundChecker>().isGrounded)
        {
            caughtByFishNet = false;
        }
    }
}
