using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayingDolphin : MonoBehaviour
{
    States state;
    PlayerController playerController;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        state = States.Alive;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (state == States.Alive)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerController.TakeDamage(1);
            }
        }
    }
}
