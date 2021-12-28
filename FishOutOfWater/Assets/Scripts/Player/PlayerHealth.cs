using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;

    private Health health;

    private PlayerController playerController;

    private SpriteRenderer[] bodyParts;

    void Start()
    {
        currentHealth = maxHealth;
        playerController = GetComponent<PlayerController>();
        health = GetComponent<Health>();
        CollectBody();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        health.SetHealth(currentHealth);
        foreach (SpriteRenderer part in bodyParts)
        {
            part.color = Color.red;
        }
        Invoke("ReturnColor", 0.1f);

        if (currentHealth <= 0)
        {
            playerController.Dead();
        }
    }

    private void CollectBody() // Gathers the different parts of the prefab with sprite renderers
    {
        bodyParts = gameObject.GetComponentsInChildren<SpriteRenderer>();
    }

    private void ReturnColor()
    {
        foreach (SpriteRenderer part in bodyParts)
        {
            part.color = Color.white;
        }
    }
}