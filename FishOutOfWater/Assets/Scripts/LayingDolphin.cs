using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayingDolphin : MonoBehaviour
{
    States state;
    PlayerHealth playerHealth;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        state = States.Alive;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (state == States.Alive)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerHealth.TakeDamage(20);
            }
        }
    }
}
