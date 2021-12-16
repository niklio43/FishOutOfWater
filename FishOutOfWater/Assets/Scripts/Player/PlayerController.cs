using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public bool isGrounded;
    public Rigidbody2D rb;
    public ParticleSystem dust;

    private Vector2 velocityCopy;
    private float thrust, jumpForce;

    private GameObject sound;
    private WeaponUpgrades state;
    private PlayerHealth playerHealth;
    private SpriteRenderer spriteRenderer;
    private FishNetController fishNetController;
    private void Start()
    {
        fishNetController = GameObject.FindGameObjectWithTag("FishNet").GetComponent<FishNetController>();
        state = WeaponUpgrades.Spray;
        sound = GameObject.FindGameObjectWithTag("AudioManager");
        isGrounded = false;
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (state == WeaponUpgrades.Regular || state == WeaponUpgrades.Spray)
        {
            jumpForce = 30;
            if (isGrounded)
            {
                thrust = 15;
            }
            else
            {
                thrust = 20;
            }
        }
        else if (state == WeaponUpgrades.Powerful)
        {
            jumpForce = 45;
            if (isGrounded)
            {
                thrust = 15;
            }
            else
            {
                thrust = 35;
            }
        }
    }

    public void Movement(int directionX, int directionY)
    {
        //To adjust the x and y variables separately
        velocityCopy = rb.velocity;
        velocityCopy.x = -directionX * thrust;
        velocityCopy.y = -directionY * jumpForce;
        rb.velocity = velocityCopy;

        if (velocityCopy.x != 0)
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
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Vertical < 0 && Horizontal == 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
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
            sound.GetComponent<AudioController>().Play("Player Damage");
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
            sound.GetComponent<AudioController>().Play("Player Damage");
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
