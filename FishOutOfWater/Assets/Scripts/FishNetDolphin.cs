using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishNetDolphin : MonoBehaviour
{
    public bool netActive;
    public GameObject fishNet;

    private int Health;
    private bool dead;
    private Vector3 target;
    private GameObject Player;
    private GameObject net;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Health = 60;
        dead = false;
        netActive = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Player != null)
            target = Player.transform.position;

        if (!dead)
            Attack();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        Health = Health - damage;
        if (Health <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        dead = true;
        Destroy(gameObject, 2);
        spriteRenderer.color = Color.red;
    }

    private void Attack()
    {
        Vector3 enemyDirectionLocal = transform.InverseTransformPoint(Player.transform.position);
        if (enemyDirectionLocal.x < 8 && enemyDirectionLocal.x > -8)
        {
            if (enemyDirectionLocal.x < 3 && enemyDirectionLocal.x > -3)
            {
                netActive = false;
            }
            else if (enemyDirectionLocal.x < 0 && !netActive)
            {
                net = Instantiate(fishNet, new Vector2(target.x, transform.position.y), transform.rotation);
                netActive = true;
            }
            else if (enemyDirectionLocal.x > 0 && !netActive)
            {
                net = Instantiate(fishNet, new Vector2(target.x, transform.position.y), transform.rotation);
                netActive = true;
            }
        }
        if (net == null)
        {
            netActive = false;
        }
    }
}
