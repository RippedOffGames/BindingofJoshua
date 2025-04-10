using UnityEngine;

public class PlayerControllerAdriana : MonoBehaviour
{
    // Movement and Shooting
    [SerializeField] private float speed;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float fireDelay;

    private float lastFire;
    private Rigidbody2D rb;

    // Bullet & Camera
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject worldCamera;
    private CameraController cameraController;

    // Transitioning Between Rooms
    private Vector3 moveByCoordinates;
    private Vector3 positionBeforeAutoMove;
    private bool isPlayerInputDisabled = false;
    private int colliderCounter = 0;

    // Health
    [SerializeField] private HealthManagerDeja healthManager;
    [SerializeField] private float health = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cameraController = worldCamera.GetComponent<CameraController>();
        healthManager = FindFirstObjectByType<HealthManagerDeja>();
    }

    void Update()
    {
        if (isPlayerInputDisabled)
        {
            transform.position = Vector3.MoveTowards(transform.position, positionBeforeAutoMove + moveByCoordinates, Time.deltaTime);

            if (transform.position == positionBeforeAutoMove + moveByCoordinates)
            {
                colliderCounter = 0;
                isPlayerInputDisabled = false;
                rb.simulated = true;
            }
        }
    }

    public void Move(Vector2 direction)
    {
        if (direction.magnitude > 1)
            direction.Normalize();

        rb.linearVelocity = direction * speed;
    }

    public void Shoot(float x, float y)
    {
        Vector2 shootDirection = new Vector2(x, y).normalized;
        Vector2 bulletSpawnPosition = (Vector2)transform.position + shootDirection * 0.5f;

        GameObject bullet = BulletPoolingAdriana.Instance.GetBullet();
        bullet.transform.position = bulletSpawnPosition;
        bullet.transform.rotation = transform.rotation;

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        if (bulletRb == null)
            bulletRb = bullet.AddComponent<Rigidbody2D>();

        bulletRb.gravityScale = 0;
        bulletRb.bodyType = RigidbodyType2D.Kinematic;
        bulletRb.linearVelocity = shootDirection * bulletSpeed;
    }

    public bool IsInputDisabled()
    {
        return isPlayerInputDisabled;
    }

    public float FireDelay => fireDelay;
    public float LastFire
    {
        get => lastFire;
        set => lastFire = value;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthManager.TakeDamage(damage);
    }

    public void Heal(float healAmount)
    {
        health += healAmount;
        healthManager.Heal(healAmount);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Door") || other.CompareTag("Bottom Door") || other.CompareTag("Left Door") ||
            other.CompareTag("Right Door") || other.CompareTag("Top Door"))
        {
            GetMoveByCoordinates(other);
            cameraController.BeginCameraMovement(other, colliderCounter);
            colliderCounter++;
        }
    }

    private void GetMoveByCoordinates(Collider2D collider)
    {
        if (collider.name.Equals("Left Door") && (colliderCounter == 0))
            moveByCoordinates = new Vector3(-2.6f, 0, 0);
        else if (collider.name.Equals("Right Door") && (colliderCounter == 0))
            moveByCoordinates = new Vector3(2.6f, 0, 0);
        else if (collider.name.Equals("Top Door") && (colliderCounter == 0))
            moveByCoordinates = new Vector3(0, 3f, 0);
        else if (collider.name.Equals("Bottom Door") && (colliderCounter == 0))
            moveByCoordinates = new Vector3(0, -3f, 0);

        positionBeforeAutoMove = transform.position;
        isPlayerInputDisabled = true;
        rb.simulated = false;
    }
}