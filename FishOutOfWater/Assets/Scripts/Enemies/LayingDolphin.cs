using UnityEngine;

public class LayingDolphin : MonoBehaviour
{

    public Animator anim;

    private int Health;
    private float speed;
    private float timer;
    private Vector2 targetPos;
    private bool isMoving, isAttacking, isDead;

    private GameObject Player;
    private SpriteRenderer[] bodyParts;
    private PlayerHealth playerHealth;

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
        CollectBody();
    }

    private void Update()
    {
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("isDead", isDead);

        if (Player.transform.position.x - gameObject.transform.position.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Player.transform.position.x - gameObject.transform.position.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Health > 0)
        {
            speed = 0.1f;
            isMoving = false;
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
        foreach(SpriteRenderer part in bodyParts)
        {
            part.color = Color.red;
        }
        Invoke("ReturnColor", 0.1f);
        if (Health <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        isMoving = false;
        isAttacking = false;
        isDead = true;
        Destroy(gameObject, 3.333f);
    }

    private void CollectBody() // Gathers the different parts of the prefab with sprite renderers
    {
        bodyParts = new SpriteRenderer[3];

        for(int i = 0; i < bodyParts.Length; i++)
        {
            if (transform.GetChild(i).CompareTag("LDBody"))
                bodyParts[i] = transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            else
                bodyParts[i] = transform.GetChild(i+2).gameObject.GetComponent<SpriteRenderer>();
        }
    }

    private void ReturnColor()
    {
        foreach(SpriteRenderer part in bodyParts)
        {
            part.color = Color.white;
        }
    }
}
