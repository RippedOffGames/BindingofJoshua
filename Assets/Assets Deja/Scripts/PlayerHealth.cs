using UnityEngine;

public class PlayerHealth : Subject
{
    public float maxHealth = 100f;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        NotifyObservers("HealthChanged");
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        NotifyObservers("HealthChanged");

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            NotifyObservers("PlayerDied");
        }
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        NotifyObservers("HealthChanged");
    }
}

