using UnityEngine;


// Max Schmit 2/28/2025
public class PlayerControllerMax: MonoBehaviour
{
    // Vars
    public float speed;
    Rigidbody2D rb;
    public GameObject bulletPrefab; // this will be the bullet prefab that we will instantiate
    public float bulletSpeed; // this will be the rate of bulletfire
    public float lastFire;
    public float fireDelay;


    // Methods
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // this will find the rigidbody2d component and set it equal to the variable rigidbody
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
        // Calculate the shooting direction and normalize it
        Vector2 shootDirection = new Vector2(x, y).normalized;

        // Calculate the bullet spawn position by moving half a unit in the shooting direction
        Vector2 bulletSpawnPosition = (Vector2)transform.position + shootDirection * 0.5f;

        // Instantiate the bullet at the calculated position and player's rotation
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition, transform.rotation) as GameObject;

        // Add a Rigidbody2D component to the bullet if it doesn't already have one
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        if (bulletRb == null)
        {
            bulletRb = bullet.AddComponent<Rigidbody2D>();
        }

        // Set the bullet's Rigidbody2D to be kinematic to prevent it from affecting the player's physics
        bulletRb.gravityScale = 0;
        bulletRb.bodyType = RigidbodyType2D.Kinematic;

        // Set the bullet's velocity based on the input direction and bullet speed
        bulletRb.linearVelocity = shootDirection * bulletSpeed;
    }

}
