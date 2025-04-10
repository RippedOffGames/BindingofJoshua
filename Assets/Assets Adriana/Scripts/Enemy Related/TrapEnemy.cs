using UnityEngine;

public class TrapEnemy : Enemy
{
    //[SerializeField]
    //private GameObject trapPrefab;
    private Transform playerTransform;
    [SerializeField]
    private float trapCooldown = 3f;
    private float nextTrapTime = 0;
    private void Awake()
    {
        GameObject player = GameObject.Find("Joshua(Player)");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }
    private void Update()
    {
        Move();
        Attack();
    }
    public override void Attack()
    {
        if(Time.time > nextTrapTime)
        {
            Debug.Log("Laid trap");
            nextTrapTime = Time.time + trapCooldown;
        }
    }

    public override void Move()
    {
        if (isShaking || playerTransform == null) return;

        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
