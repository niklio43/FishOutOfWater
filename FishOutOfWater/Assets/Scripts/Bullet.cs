using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject PlayerBullet;
    public GameObject EnemyBullet;

    private Vector2 BulletScreenPosition;

    private void Update()
    {
        BulletScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (BulletScreenPosition.x > Screen.width || BulletScreenPosition.x < 0)
        {
            Destroy(gameObject);
        }
        if (BulletScreenPosition.y > Screen.height || BulletScreenPosition.y < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
