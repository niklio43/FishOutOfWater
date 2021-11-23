using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private States state;
    private SpriteRenderer spriteRenderer;
    private int Health;
    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        Health = 8;
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
            Dead();
    }

    private void Dead()
    {
        Destroy(gameObject, 2);
        spriteRenderer.color = Color.red;
    }
}
