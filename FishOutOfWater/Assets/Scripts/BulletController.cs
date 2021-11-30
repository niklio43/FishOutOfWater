using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(rb.velocity == new Vector2(0, 0))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if (gameObject.tag == "Bullet" && collision.gameObject.tag =="Bullet")
        {
            Destroy(gameObject);
        }
        if (gameObject.tag == "EnemyBullet" && collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject);
        }
    }
}
