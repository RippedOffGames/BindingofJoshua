//Deja Hang
//5/6/25

using UnityEngine;

public class Game3Enemy : MonoBehaviour, IEnemy
{
    // Variables
    public int damage = 1;
    public int maxHealth = 3;
    protected int currentHealth;

    //Methods
    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}

