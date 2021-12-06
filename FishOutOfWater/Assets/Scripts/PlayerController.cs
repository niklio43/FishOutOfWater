using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float thrust, jumpForce;
    public Rigidbody2D rb;
    public ParticleSystem dust;

    private Vector2 velocityCopy;
    private PlayerHealth playerHealth;
    private SpriteRenderer spriteRenderer;
    private FishNetController fishNetController;

    public bool isGrounded;

    private void Start()
    {
        isGrounded = false;
        jumpForce = 30;
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("FishNet") != null)
            fishNetController = GameObject.FindGameObjectWithTag("FishNet").GetComponent<FishNetController>();

        if (isGrounded)
        {
            thrust = 15;
        }
        else
        {
            thrust = 20;
        }
    }

    public void Movement(int directionX, int directionY)
    {
        if (fishNetController == null || !fishNetController.caughtByFishNet)
        {
            velocityCopy = rb.velocity; //To adjust the x and y variables separately
            velocityCopy.x = -directionX * thrust;
            velocityCopy.y = -directionY * jumpForce;
            rb.velocity = velocityCopy;

            if (velocityCopy.x != 0)
            {
                CreateDust();
            }
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
        SceneManager.LoadScene("Amelie");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            playerHealth.TakeDamage(20);
        }
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("LayingDolphin") ||
            collision.gameObject.CompareTag("StandingDolphin") || collision.gameObject.CompareTag("Spike") ||
            collision.gameObject.CompareTag("ToxicBarrel"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            playerHealth.TakeDamage(20);
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
