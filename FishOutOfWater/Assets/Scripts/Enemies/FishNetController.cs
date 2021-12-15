using UnityEngine;

public class FishNetController : MonoBehaviour
{
    public bool caughtByFishNet;

    private NetTrigger netTrigger;

    private GameObject Player;

    private void Start()
    {
        caughtByFishNet = false;
        netTrigger = GameObject.FindGameObjectWithTag("netTrigger").GetComponent<NetTrigger>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    //private void Update()
    //{
    //    if (caughtByFishNet)
    //    {
    //        netTrigger.throwing = false;
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("FishNetDolphin") || collision.gameObject.CompareTag("Spike"))
        {
            Physics2D.IgnoreLayerCollision(9, 8);
            Physics2D.IgnoreLayerCollision(11, 8);
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
        if (collision.CompareTag("Player"))
        {
            collision.attachedRigidbody.velocity = gameObject.GetComponent<Rigidbody2D>().velocity;

            if (caughtByFishNet && Player.GetComponent<PlayerController>().isGrounded)
            {
                caughtByFishNet = false;
            }
        }
    }
}
