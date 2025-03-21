using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Max Schmit 2/28/2025
public class BulletControllerAdriana : MonoBehaviour
{
    public float lifeTime;

    void OnEnable()
    {
        StartCoroutine(DeactivateAfterTime());
    }

    IEnumerator DeactivateAfterTime()
    {
        yield return new WaitForSeconds(lifeTime); // Wait for lifeTime seconds
        if (BulletPoolingAdriana.Instance != null)
        {
            BulletPoolingAdriana.Instance.ReturnBullet(gameObject); // Return to pool when time is up
        }
        else
        {
            Destroy(gameObject); // Destroy if pool is missing for whatever reason idk why this happens but it does
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(1); // Deal 1 damage per hit
        }

        BulletPoolingAdriana.Instance.ReturnBullet(gameObject);
    }
}
