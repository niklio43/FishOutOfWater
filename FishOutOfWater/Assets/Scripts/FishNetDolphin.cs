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
        /*target = transform.position - Player.transform.position;

        if(target.x <= 3f && target.y <= 5f && netActive == false)
        {
            net = Instantiate(fishNet, new Vector2(transform.position.x - 3.1f, transform.position.y), transform.rotation);
            netActive = true;
        }

        if(net == null)
        {
            netActive = false;
        }
    }*/

        Vector3 direction = transform.position - target;
        Debug.Log("dir: "+direction.x);
        Debug.Log("tar: " + target.x);
        if (direction.y < 20f)
        {
            if (direction.x > transform.position.x && !netActive) // spelare är till höger om enemy
            {
                if(direction.x > 2 && direction.x < 10)
                {
                    net = Instantiate(fishNet, new Vector2(-direction.x - 3f, transform.position.y), transform.rotation);
                    netActive = true;
                }
            }
            else if (direction.x < transform.position.x && !netActive) // spelare är till vänster om enemy
            {
                if(direction.x < 2 && direction.x > -10)
                {
                    net = Instantiate(fishNet, new Vector2(-direction.x - 3f, transform.position.y), transform.rotation);
                    netActive = true;
                }
            }
        }
        else
        {
            netActive = false;
        }

        if (net == null)
        {
            netActive = false;
        }
    }
}
