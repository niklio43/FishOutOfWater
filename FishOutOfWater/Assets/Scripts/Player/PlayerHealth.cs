using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;

    private int maxHealth = 20;
    private SpriteRenderer[] bodyParts;
    private PlayerController playerController;

    void Start()
    {
        currentHealth = maxHealth;
        playerController = GetComponent<PlayerController>();
        CollectBody();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
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