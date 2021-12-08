using UnityEngine;

public class LayingDolphin : MonoBehaviour
{
    private int Health;
    private PlayerHealth playerHealth;

    void Start()
    {
        Health = 60;
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
    }
}
