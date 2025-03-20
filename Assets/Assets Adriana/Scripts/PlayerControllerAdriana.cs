using UnityEngine;


// Max Schmit 2/28/2025
public class PlayerControllerAdriana: MonoBehaviour
{
    // Vars
    public float speed;
    Rigidbody2D rb;
    public GameObject bulletPrefab; // this will be the bullet prefab that we will instantiate
    public float bulletSpeed; // this will be the rate of bulletfire
    public float lastFire;
    public float fireDelay;

    // Adriana Vars
    [SerializeField]
    GameObject worldCamera;
    CameraController cameraController;
    Vector3 moveByCoordinates;
    Vector3 positionBeforeAutoMove;
    private bool isPlayerInputDisabled = false;
    private int colliderCounter = 0;

    // Methods
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // this will find the rigidbody2d component and set it equal to the variable rigidbody
        cameraController = worldCamera.GetComponent<CameraController>();
    }

    private void Update() // called once per frame
    {

        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical"); 

        //Adriana code to disable input when move transition is happening 
        if (isPlayerInputDisabled)
        {
            horizontal = 0;
            vertical = 0;
            transform.position = Vector3.MoveTowards(transform.position, positionBeforeAutoMove + moveByCoordinates, Time.deltaTime); // Smoothly moves the player

            if (transform.position == positionBeforeAutoMove + moveByCoordinates) // When player is done moving reset rigidbody, enable input and the collider couinter
            {
                colliderCounter = 0;
                isPlayerInputDisabled = false;
                rb.simulated = true;
            }

        }

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

        GameObject bullet = BulletPoolingAdriana.Instance.GetBullet();
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

    /*
    Adrian Seda
    Trash but works
    move player when they enter a door
    */
    private void OnTriggerEnter2D(Collider2D other)
    {
        GetMoveByCoordinates(other);
        cameraController.BeginCameraMovement(other, colliderCounter);
        colliderCounter++;
    }

    /*
    Figures out which door we touched and what direction
    to move the player.

    Uses a counter becasue there are double doors.

    For example the right door of the room the player is in
    is immidiately next to the left door of the next room.
    Without counter player gets sent back when they touch the other collider.
    */
    private void GetMoveByCoordinates(Collider2D collider)
    {

        if (collider.name.Equals("Left Door") && (colliderCounter == 0))
        {
            moveByCoordinates = new Vector3(-2.6f, 0, 0);
        }
        else if(collider.name.Equals("Right Door") && (colliderCounter == 0))
        {
            moveByCoordinates = new Vector3(2.6f, 0, 0);
        }
        else if (collider.name.Equals("Top Door") && (colliderCounter == 0))
        {
            moveByCoordinates = new Vector3(0, 3f, 0);
        }
        else if (collider.name.Equals("Bottom Door") && (colliderCounter == 0))
        {
            moveByCoordinates = new Vector3(0,-3f, 0);
        }
 
        positionBeforeAutoMove = transform.position; //save the position of the player before starting the move
        isPlayerInputDisabled = true;
        rb.simulated = false; //disable the rigidbody 
    }
    
}
