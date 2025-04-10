using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField]
    private float maxDistanceFromPlayer;
    private Transform playerTransform;
    [SerializeField]
    private float bulletCooldown = 2f;
    private float nextBulletTime;
    void Awake()
    {
        GameObject player = GameObject.Find("Joshua(Player)");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
    }

    public override void Move()
    {
        if (isShaking)
        {
       
            return;
        }

        if (playerTransform == null)
        {
          
            return;
        }

        float distance = Vector3.Distance(transform.position, playerTransform.position);
    

        if (distance > maxDistanceFromPlayer)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
       
        }
    }
    public override void Attack()
    {
        if (Time.time < nextBulletTime) 
        {
            Debug.Log("Shoot");
            nextBulletTime = Time.time + bulletCooldown;
        }

    }

}
