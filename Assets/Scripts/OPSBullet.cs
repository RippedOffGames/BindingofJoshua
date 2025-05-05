using UnityEngine;
using UnityEngine.Pool;
/*
Adriana Seda Pagan
Bullet Component

Some Object Pooling code to release a bullet back to the pool
Not an observer as does not require real time updates from the game manager
to see if we are in rampage mode

 */
public class OPSBullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    private float lifetime = 2f;
    private float lifetimer;
    private IObjectPool<OPSBullet> bulletPool;

    private Vector2 direction;

    private int baseDamage = 34;
    private int rampageDamage = 100;

    // Called by the GunController to set the direction
    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    // Get reference to the pool from the gun controller
    public void SetPool(IObjectPool<OPSBullet> pool)
    {
        bulletPool = pool;
    }
  
    private void OnEnable()
    {
        lifetimer = lifetime;
    }

    // Move the bullet and decrement how long it has left to live every update
    void Update()
    {
        // Move the bullet in the set direction.
        transform.Translate(direction * speed * Time.deltaTime);
        lifetimer -= Time.deltaTime;
        if ( lifetimer < 0)
        {
            bulletPool.Release(this);
        }
    }

    // When the bullet collides with an enemy, deal damage but check how much to do
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            int damageToDeal = OPSGameManager.Instance.IsRampageActive ? rampageDamage : baseDamage;
            other.gameObject.GetComponent<OPSEnemyHealth>().EnemyDamage(damageToDeal);
            bulletPool.Release(this);
        }
    }
}