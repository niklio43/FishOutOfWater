using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicBarrel : MonoBehaviour
{
    public ParticleSystem toxicExplosion;
    private PlayerHealth playerHealth;
    public bool invincible;

    private void Start()
    {
        invincible = false;
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Player") && !invincible)
        {
            playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(20);
            invincible = true;

            Invoke("resetInvulnerability", 1);
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
