using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (gameObject.tag == "Bullet" && collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }

        if (gameObject.tag == "EnemyBullet" && collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject);
        }
    }
}
