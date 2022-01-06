using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingDolphin : MonoBehaviour
{
    public bool isDead;
    public Animator anim;
    public GameObject Bullet;

    private int Health;
    private bool isAttacking;
    private Alerted alerted;
    private GameObject Player;
    private AudioController sound;
    private float fireRate, nextFire;
    private SpriteRenderer[] bodyParts;

    void Start()
    {
        alerted = GetComponent<Alerted>();
        isDead = false;
        isAttacking = false;
        Health = 60;
        nextFire = -1f;
        fireRate = 1.1f;
        sound = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioController>();
        Player = GameObject.FindGameObjectWithTag("Player");
        CollectBody();
    }

    void Update()
    {
        anim.SetBool("isAttacking", isAttacking);
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
        if (collision.gameObject.CompareTag("Player") && nextFire < 0 && !isDead)
        {
            isAttacking = true;
            GameObject bullet = Instantiate(Bullet, transform.GetChild(0).gameObject.transform.position, transform.rotation);
            if(transform.eulerAngles.y == 180)
            {
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
            }
            else
            {
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
            }
            nextFire = fireRate;
            sound.Play("Enemy Fire");
            Destroy(bullet, 3);
        }
        else
        {
            isAttacking = false;
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isDead)
        {
            Health = Health - damage;
            foreach (SpriteRenderer part in bodyParts)
            {
                part.color = Color.red;
            }
            Invoke("ReturnColor", 0.1f);
        }

        if (Health <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        alerted.isActive = false;
        isAttacking = false;
        isDead = true;
        anim.SetTrigger("isDead");
        Destroy(gameObject, 2);
    }

    private void CollectBody()
    {
        bodyParts = new SpriteRenderer[3];

        for (int i = 0; i < bodyParts.Length; i++)
        {
            if ((i + 1) == 1)
            {
                bodyParts[i] = transform.GetChild(i + 1).gameObject.GetComponent<SpriteRenderer>();
            }
            else if ((i + 3) == 4)
            {
                bodyParts[i] = transform.GetChild(i + 3).gameObject.GetComponent<SpriteRenderer>();
            }
            else if ((i + 3) == 5)
            {
                bodyParts[i] = transform.GetChild(i + 3).gameObject.GetComponent<SpriteRenderer>();
            }
        }
    }

    private void ReturnColor()
    {
        foreach (SpriteRenderer part in bodyParts)
        {
            part.color = Color.white;
        }
    }
}
