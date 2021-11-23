using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int hp;
    private States state;
    void Start()
    {
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
        if(state == States.Alive)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(collision.gameObject);
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
            Destroy(gameObject, 2);
        }
    }
}
