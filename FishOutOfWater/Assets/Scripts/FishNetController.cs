using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishNetController : MonoBehaviour
{
    public bool caughtByFishNet;

    private GameObject Player;

    private void Start()
    {
        caughtByFishNet = false;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("LayingDolphin") || collision.gameObject.CompareTag("StandingDolphin") || collision.gameObject.CompareTag("FishNetDolphin"))
        {
            Destroy(gameObject, 1.2f);
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
                Destroy(gameObject);
            }
        }
    }
}
