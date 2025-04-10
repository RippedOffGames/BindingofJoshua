using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    private int damage = 1;
    protected bool isShaking = false;
    public abstract void Attack();
    public abstract void Move();

    public virtual void TakeDamage(float damageTaken)
    {
        health -= damageTaken;

        StartCoroutine(ShakeEffect());
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        if (sr != null) sr.color = Color.red;
        Invoke(nameof(ResetColor), 0.1f); // Reset color after 0.1 seconds

        if (health <= 0)
        {
            Die();
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            TakeDamage(1);
            BulletPoolingAdriana.Instance.ReturnBullet(other.gameObject);
        }
    }

    void ApplyPowerUp(string powerUpTag)
    {
        IMovementStrategyDeja strategy = StrategyFactoryDeja.GetStrategy(powerUpTag);
        if (strategy != null)
        {
            speed = strategy.GetSpeed();
            health += strategy.GetHealthBoost();
            damage += strategy.GetDamageBoost();

            Debug.Log($"Power-up Applied! Speed: {speed}, Health: {health}, Damage: {damage}");
        }
    }
    private void ResetColor()
    {
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        if (sr != null) sr.color = Color.white;
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
    private IEnumerator ShakeEffect()
    {
        isShaking = true;
        Vector3 originalPosition = transform.localPosition;
        float shakeAmount = 0.1f;

        for (int i = 0; i < 5; i++)
        {
            Vector3 offset = Random.insideUnitCircle * shakeAmount;
            transform.localPosition = originalPosition + offset;
            yield return new WaitForSeconds(0.02f);
        }

        transform.localPosition = originalPosition;
        isShaking = false;
    }
}

