using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayingDolphin : MonoBehaviour
{
    public States state;

    private GameObject player;
    private PlayerHealth playerHealth;

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
