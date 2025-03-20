using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int damage;

    public abstract void Attack();
    public abstract void Move();

    public virtual void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        if (health < 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
