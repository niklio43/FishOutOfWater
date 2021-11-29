using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float thrust, jumpForce;
    private PlayerHealth playerHealth;
    private SpriteRenderer spriteRenderer;
    private Vector2 velocityCopy;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    public void Movement(int directionX, int directionY)
    {
        velocityCopy = rb.velocity;
        velocityCopy.x = -directionX * thrust;
        velocityCopy.y = -directionY * jumpForce;
        rb.velocity = velocityCopy;
    }

    public void SetPlayerRotation(int Horizontal, int Vertical)
    {
        if (Horizontal > 0 && Vertical == 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Horizontal < 0 && Vertical == 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Vertical > 0 && Horizontal == 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (Vertical < 0 && Horizontal == 0)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
    }


    public void SwitchGravity(float GravityScale)
    {
        rb.gravityScale = GravityScale;
    }

    public void Dead()
    {
        spriteRenderer.color = Color.red;
        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            playerHealth.TakeDamage(20);
        }
    }
}
