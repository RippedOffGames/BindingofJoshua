using UnityEngine;


// Max Schmit 2/28/2025
public class PlayerControllerMax : MonoBehaviour
{
    // Vars
    public static PlayerControllerMax Instance { get; private set; }


    public float speed;
    Rigidbody2D rb;
    public GameObject bulletPrefab; // this will be the bullet prefab that we will instantiate
    public float bulletSpeed; // this will be the rate of bulletfire
    public float lastFire;
    public float fireDelay;


    // Methods
    private void Awake()
    {
        // Ensure that there is only one instance of PlayerControllerMax
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SaveControllerMax.Load(); // Load game state when the player starts
    }



    private void Update() // called once per frame
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        // defining shoot horizintal and shoot vertical
        float shootHor = Input.GetAxis("ShootHorizontal");
        float shootVert = Input.GetAxis("ShootVertical");

        if ((shootHor != 0 || shootVert != 0) && Time.time > lastFire + fireDelay) // this will check if the shoot horizontal or shoot vertical is not equal to 0 and if the time is greater than the last fire plus the fire delay
        {
            if (Mathf.Abs(shootHor) > Mathf.Abs(shootVert)) // this will check if the absolute value of the shoot horizontal is greater than the absolute value of the shoot vertical
            {
                Shoot(shootHor, 0); // this will set the shoot vertical to 0
            }
            else
            {
                Shoot(0, shootVert); // this will set the shoot horizontal to 0
            }
            lastFire = Time.time; // this will set the last fire to the current time
        }


        Vector2 movement = new Vector2(horizontal, vertical); // this will create a new vector2 with the horizontal and vertical input

        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }
        rb.linearVelocity = movement * speed; // this will set the velocity of the rigidbody to the movement vector multiplied by the speed


    }

    void Shoot(float x, float y)
    {
        Vector2 shootDirection = new Vector2(x, y).normalized;
        Vector2 bulletSpawnPosition = (Vector2)transform.position + shootDirection * 0.5f;

        GameObject bullet = BulletPool.Instance.GetBullet();
        bullet.transform.position = bulletSpawnPosition;
        bullet.transform.rotation = transform.rotation;

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        if (bulletRb == null)
        {
            bulletRb = bullet.AddComponent<Rigidbody2D>();
        }

        bulletRb.gravityScale = 0;
        bulletRb.bodyType = RigidbodyType2D.Kinematic;
        bulletRb.linearVelocity = shootDirection * bulletSpeed;
    }



    public void Save(ref PlayerSaveData data)
    {
        data.Position = transform.position;
    }

    public void Load(ref PlayerSaveData data)
    {
        transform.position = data.Position;
    }

    void OnApplicationQuit()
    {
        SaveControllerMax.Save();
    }


}


[System.Serializable]
public struct PlayerSaveData
{
    public Vector3 Position;
}