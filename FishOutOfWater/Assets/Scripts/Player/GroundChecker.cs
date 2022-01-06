using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGrounded;

    private GameObject sound;
    private PlayerHealth playerHealth;

    void Start()
    {
        isGrounded = false;
        sound = GameObject.FindGameObjectWithTag("AudioManager");
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            playerHealth.TakeDamage(20);
            sound.GetComponent<AudioController>().Play("Player Damage");
        }
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("LayingDolphin") ||
            collision.gameObject.CompareTag("StandingDolphin") || collision.gameObject.CompareTag("Spike") ||
            collision.gameObject.CompareTag("ToxicBarrel"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            playerHealth.TakeDamage(20);
            sound.GetComponent<AudioController>().Play("Player Damage");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("LayingDolphin") ||
            collision.gameObject.CompareTag("StandingDolphin") || collision.gameObject.CompareTag("Spike") ||
            collision.gameObject.CompareTag("ToxicBarrel"))
        {
            isGrounded = false;
        }
    }
}
