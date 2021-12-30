using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public ParticleSystem dust;

    private Vector2 velocityCopy;
    public float thrust, jumpForce;

    private GameObject sound;
    private WeaponUpgrades state;
    private PlayerHealth playerHealth;

    private GroundChecker groundChecker;

    public int deathCounter;

    private bool Slowed;

    private void Start()
    {
        deathCounter = 0;
        Slowed = false;
        groundChecker = GameObject.FindGameObjectWithTag("PlayerBottom").GetComponent<GroundChecker>();
        state = WeaponUpgrades.Spray;
        sound = GameObject.FindGameObjectWithTag("AudioManager");
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (state == WeaponUpgrades.Regular && !Slowed || state == WeaponUpgrades.Spray && !Slowed)
        {
            jumpForce = 30;
            if (groundChecker.isGrounded)
            {
                thrust = 15;
                jumpForce = 50;
            }
            else
            {
                thrust = 25;
                jumpForce = 35;
            }
        }
        else if (state == WeaponUpgrades.Powerful && !Slowed)
        {
            jumpForce = 45;
            if (groundChecker.isGrounded)
            {
                thrust = 15;
                jumpForce = 60;
            }
            else
            {
                thrust = 35;
                jumpForce = 45;
            }
        }
        else if(Slowed)
        {
            thrust = 8;
            jumpForce = 30;
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

    public void Drift(int directionX)
    {
        velocityCopy = rb.velocity;
        velocityCopy.x = -directionX * 8;
        velocityCopy.y = -12;
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
        deathCounter++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            playerHealth.TakeDamage(20);
            sound.GetComponent<AudioController>().Play("Player Damage");
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            playerHealth.TakeDamage(20);
            sound.GetComponent<AudioController>().Play("Player Damage");
        }
        if (collision.gameObject.CompareTag("ToxicWater"))
        {
            playerHealth.TakeDamage(20);
            sound.GetComponent<AudioController>().Play("Player Damage");
        }
    }

    public void CreateDust()
    {
        dust.Play();
    }
}
