using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGrounded;

    private PlayerHealth playerHealth;

    private GameObject sound;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        sound = GameObject.FindGameObjectWithTag("AudioManager");
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
