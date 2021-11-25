using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayingDolphin : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth playerHealth;

    public States state;

    void Start()
    {
        state = States.Alive;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
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
