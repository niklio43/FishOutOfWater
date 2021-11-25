using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public States state;
    public HealthBar healthBar;

    private PlayerController playerController;

    void Start()
    {
        state = States.Alive;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerController = GetComponent<PlayerController>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            playerController.Dead();
            state = States.Dead;
        }
    }
}
