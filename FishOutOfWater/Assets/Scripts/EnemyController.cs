using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private StandingDolphin standingDolphin;
    private LayingDolphin layingDolphin;
    private GameObject StandingD;
    private GameObject LayingD;
    private int Health;

    void Start()
    {
        StandingD = GameObject.FindGameObjectWithTag("Mouth");
        LayingD = GameObject.FindGameObjectWithTag("LayingDolphin");
        standingDolphin = StandingD.GetComponent<StandingDolphin>();
        layingDolphin = LayingD.GetComponent<LayingDolphin>();
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
                layingDolphin.state = States.Dead;
                Dead();
            }
            if (gameObject.tag == "StandingDolphin")
            {
                standingDolphin.state = States.Dead;
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
