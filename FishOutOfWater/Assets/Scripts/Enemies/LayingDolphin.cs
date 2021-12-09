using UnityEngine;

public class LayingDolphin : MonoBehaviour
{
    private int Health;
    private GameObject Player;
    private PlayerHealth playerHealth;
    private Vector2 targetPos;

    private bool isMoving, isAttacking, isDead;

    public Animator anim;

    private float speed;

    private float timer;

    void Start()
    {
        speed = 8f;
        isMoving = false;
        isMoving = false;
        isDead = false;
        Health = 60;
        Player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = Player.GetComponent<PlayerHealth>();
        timer = 0;
    }

    private void Update()
    {
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("isDead", isDead);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Health > 0)
        {
            speed = 0.1f;
            isAttacking = true;

            timer += Time.deltaTime;
            if (timer >= 1 && Player != null)
            {
                playerHealth.TakeDamage(20);
                timer = 0;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        speed = 8f;
        isAttacking = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Health > 0)
        {
            isMoving = true;
            targetPos = Player.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isMoving = false;
    }

    public void TakeDamage(int damage)
    {
        Health = Health - damage;
        if (Health <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        isDead = true;
        Destroy(gameObject, 2);
    }
}
