using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicBarrel : MonoBehaviour
{
    public ParticleSystem toxicExplosion;
    private PlayerHealth playerHealth;

    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(20);
        }
    }

    public void CreateToxicExplosion()
    {
        toxicExplosion.Play();
    }
}
