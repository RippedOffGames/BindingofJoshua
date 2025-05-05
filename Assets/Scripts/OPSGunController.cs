using UnityEngine;
using UnityEngine.Pool;
/*
Adriana Seda Pagan
Guncontroller to handle shooting
Defines the object pool to use object pooling
with bullets
*/
public class GunController : MonoBehaviour
{
    [SerializeField]
    private OPSBullet bulletPrefab;
    [SerializeField]
    private float shootingCooldown = 1f;

    // Cooldown timer.
    private float nextFireTime = 0f;

    // Hold when the key was pressed last
    private float lastUpPressed = -1f;
    private float lastDownPressed = -1f;
    private float lastLeftPressed = -1f;
    private float lastRightPressed = -1f;

    private IObjectPool<OPSBullet> bulletPool;

    private void Awake()
    {
        bulletPool = new ObjectPool<OPSBullet>(CreateOPSBullet, OnGet, OnRelease);
    }

    void Update()
    {
        // Record key press time stamp
        if (Input.GetKeyDown(KeyCode.UpArrow))
            lastUpPressed = Time.time;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            lastDownPressed = Time.time;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            lastLeftPressed = Time.time;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            lastRightPressed = Time.time;

        // Only attempt to shoot if the cooldown period has passed
        if (Time.time >= nextFireTime)
        {
            Vector2 shootDirection = GetShootingDirection();

            if (shootDirection != Vector2.zero)
            {
                Shoot(shootDirection);
                nextFireTime = Time.time + shootingCooldown;
            }
        }
    }

    // Create a bullet and give the bullet a reference to the pool
    private OPSBullet CreateOPSBullet()
    {
        OPSBullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.SetPool(bulletPool);
        return bullet;
    }

    // Activate the object and set its position to the player as guncontroller is attached to player
    private void OnGet(OPSBullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = transform.position;
    }

    // Disable the bullet when Release is called
    private void OnRelease(OPSBullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
    // Determines the current shooting direction based on which arrow key is held and the last pressed time
    private Vector2 GetShootingDirection()
    {
        Vector2 dir = Vector2.zero;
        float maxTime = -1f;

        // Check each arrow key: if it is held down and its last pressed time is the most recent, update the direction
        if (Input.GetKey(KeyCode.UpArrow) && lastUpPressed > maxTime)
        {
            maxTime = lastUpPressed;
            dir = Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow) && lastDownPressed > maxTime)
        {
            maxTime = lastDownPressed;
            dir = Vector2.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && lastLeftPressed > maxTime)
        {
            maxTime = lastLeftPressed;
            dir = Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow) && lastRightPressed > maxTime)
        {
            maxTime = lastRightPressed;
            dir = Vector2.right;
        }

        return dir;
    }

    private void Shoot(Vector2 direction)
    {
        OPSBullet bullet = bulletPool.Get();

        // Set the bullet's travel direction
        OPSBullet bulletScript = bullet.GetComponent<OPSBullet>();
        if (bulletScript != null)
        {
            bulletScript.SetDirection(direction);
        }

        // To prevent the bullet from colliding with the player at instantiation
        // ignore their collision
        Collider2D playerCollider = GetComponent<Collider2D>();
        Collider2D bulletCollider = bullet.GetComponent<Collider2D>();
        if (playerCollider != null && bulletCollider != null)
        {
            Physics2D.IgnoreCollision(playerCollider, bulletCollider);
        }
    }
}
