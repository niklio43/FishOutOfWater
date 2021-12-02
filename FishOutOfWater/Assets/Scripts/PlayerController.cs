using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float thrust, jumpForce;
    public Rigidbody2D rb;
    public ParticleSystem dust;

    private Vector2 velocityCopy;
    private PlayerHealth playerHealth;
    private SpriteRenderer spriteRenderer;

    public bool isGrounded;

    private void Start()
    {
        isGrounded = false;
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Movement(int directionX, int directionY)
    {
        velocityCopy = rb.velocity; //To adjust the x and y variables separately
        velocityCopy.x = -directionX * thrust;
        velocityCopy.y = -directionY * jumpForce;
        rb.velocity = velocityCopy;

        if(velocityCopy.x != 0)
        {
            CreateDust();
        }
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void CreateDust()
    {
        dust.Play();
    }
}
