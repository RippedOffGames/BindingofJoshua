//Deja Hang
//5/6/25

using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Variables
    public int bulletDamage = 1;
    public float bulletSpeed = 50f;

    //Methods
    public virtual void Shoot(Vector3 direction)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IEnemy enemy = collision.GetComponent<IEnemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}

