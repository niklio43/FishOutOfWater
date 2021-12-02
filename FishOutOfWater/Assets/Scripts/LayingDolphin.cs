using UnityEngine;

public class LayingDolphin : MonoBehaviour
{
    private int Health;
    private PlayerHealth playerHealth;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Health = 60;
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(20);
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
        spriteRenderer.color = Color.red;
    }
}
