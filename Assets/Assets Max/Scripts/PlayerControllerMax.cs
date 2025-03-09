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
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject; // this will instantiate the bullet prefab at the position of the player and the rotation of the player

        bullet.AddComponent<Rigidbody2D>().gravityScale = 0; // this will add a rigidbody2d component to the bullet and set the gravity scale to 0 POWERUP/EFFECT POTENTIAL
        bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2( // this will set the velocity of the bullet to the x and y input multiplied by the bullet speed
            (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed, // this will set the x velocity of the bullet to the x input multiplied by the bullet speed
            (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed);// this will set the y velocity of the bullet to the y input multiplied by the bullet speed
    }

}
