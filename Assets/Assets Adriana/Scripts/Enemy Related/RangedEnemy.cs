using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField]
    private float minDistanceFromPlayer;
    private Transform playerTransform;
    [SerializeField]
    private float bulletCooldown = 2f;
    private float nextBulletTime;
    void Start()
    {
        GameObject player = GameObject.Find("Joshua(Player");
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
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance < minDistanceFromPlayer)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
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
