using UnityEngine;

public class LayingDolphin : MonoBehaviour
{
    private int Health;
    private GameObject Player;
    private PlayerHealth playerHealth;
    private Vector2 targetPos;

    void Start()
    {
        Health = 60;
        Player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = Player.GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Health > 0)
        {
            playerHealth.TakeDamage(20);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Health > 0)
        {
            targetPos = Player.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 15 * Time.deltaTime);
        }
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
        Destroy(gameObject, 2);
    }
}
