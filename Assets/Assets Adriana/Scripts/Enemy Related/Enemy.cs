using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    private GameObject damageNumberPrefab;  
    private Transform damageNumberSpawnPoint;
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
        Vector3 originalPosition = transform.position;
        float shakeAmount = 0.1f;

        for (int i = 0; i < 5; i++)
        {
            transform.position = originalPosition + (Vector3)Random.insideUnitCircle * shakeAmount;
            yield return new WaitForSeconds(0.02f);
        }

        transform.position = originalPosition;
    }
}

