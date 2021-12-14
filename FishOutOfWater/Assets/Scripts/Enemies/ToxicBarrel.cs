using UnityEngine;

public class ToxicBarrel : MonoBehaviour
{
    public bool invincible;

    public ParticleSystem toxicExplosion;

    private PlayerHealth playerHealth;

    private void Start()
    {
        invincible = false;
    }

    void OnParticleCollision(GameObject collision)
    {
        if (collision.gameObject.CompareTag("Player") && !invincible)
        {
            playerHealth = collision.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(20);
            invincible = true;

            var playerVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;

            if(playerVelocity.y < 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = playerVelocity + new Vector2(0, 1) * 40;
            }

            if(playerVelocity == new Vector2(0, 0))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = playerVelocity + new Vector2(1, 1) * 40;
            }
            else if( playerVelocity.y > 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = playerVelocity * 20;
            }

            Invoke("resetInvulnerability", 0.5f);
        }
    }

    public void CreateToxicExplosion()
    {
        toxicExplosion.Play();
    }

    private void resetInvulnerability()
    {
        invincible = false;
    }
}
