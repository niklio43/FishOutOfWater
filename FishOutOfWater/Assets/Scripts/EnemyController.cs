using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    int hp;
    private States state;
    private PlayerController playercontroller;
    private SpriteRenderer rend;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playercontroller = player.GetComponent<PlayerController>();
        rend = GetComponent<SpriteRenderer>();
        state = States.Alive;
        hp = 4;
    }

    void Update()
    {
        Dying();
        if(hp <= 0)
        {
            state = States.Dead;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(state == States.Alive) //can only hurt player if still alive
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playercontroller.TakeDamage(1);
            }
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            hp--;
        }
    }
    private void Dying()
    {
        if(state == States.Dead)
        {
            //play death animation
            rend.color = Color.blue;
            Destroy(gameObject, 2);
        }
    }
}
