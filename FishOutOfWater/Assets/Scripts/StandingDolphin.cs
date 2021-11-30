using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingDolphin : MonoBehaviour
{
    public GameObject Bullet;

    private int Health;
    private Vector3 Target;
    private float fireRate, nextFire;

    private GameObject Player;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Health = 60;
        nextFire = -1f;
        fireRate = 0.4f;
        Player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Player != null && Health != 0)
        {
            if (Player.transform.position.x > transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        if (nextFire > 0)
        {
            nextFire -= Time.deltaTime;
        }
    }

    //If player enters trigger, dolphin starts shooting towards player
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && nextFire < 0)
        {
            GameObject bullet = Instantiate(Bullet, GameObject.FindGameObjectWithTag("Mouth").transform.position, transform.rotation);
            Target = Player.transform.position - transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = Target * 10f;
            nextFire = fireRate;
            Destroy(bullet, 3);
        }
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
        Destroy(gameObject, 2);
        spriteRenderer.color = Color.red;
    }
}
