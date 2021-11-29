using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int Health;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Health = 8;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        Health = Health - damage;
        if (Health <= 0)
        {
            if(gameObject.tag == "LayingDolphin")
            {
                Dead();
            }
            if (gameObject.tag == "StandingDolphin")
            {
                Dead();
            }
        }
    }

    private void Dead()
    {
        Destroy(gameObject, 2);
        spriteRenderer.color = Color.red;
    }
}
