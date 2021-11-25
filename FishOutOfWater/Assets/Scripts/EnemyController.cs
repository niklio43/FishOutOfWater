using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int Health;
    private GameObject LayingD;
    private GameObject StandingD;
    private LayingDolphin layingDolphin;
    private StandingDolphin standingDolphin;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Health = 8;
        spriteRenderer = GetComponent<SpriteRenderer>();
        LayingD = GameObject.FindGameObjectWithTag("LayingDolphin");
        layingDolphin = LayingD.GetComponent<LayingDolphin>();
        StandingD = GameObject.FindGameObjectWithTag("Mouth");
        standingDolphin = StandingD.GetComponent<StandingDolphin>();
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
