using UnityEngine;

public class FishNetController : MonoBehaviour
{
    public bool caughtByFishNet;

    private GameObject Player;

    private FishNetDolphin fishNetDolphin;

    private void Start()
    {
        fishNetDolphin = transform.GetComponentInParent<FishNetDolphin>();
        caughtByFishNet = false;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("FishNetDolphin"))
        {
            Physics2D.IgnoreLayerCollision(9, 8);
        }

        if (collision.gameObject.CompareTag("Ground") || 
            collision.gameObject.CompareTag("LayingDolphin") || 
            collision.gameObject.CompareTag("StandingDolphin"))
        {
            Destroy(gameObject, 2);
            StartCoroutine(fishNetDolphin.CreateFishnet());
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
                Destroy(gameObject, 2);
                StartCoroutine(fishNetDolphin.CreateFishnet());
            }
        }
    }
}
