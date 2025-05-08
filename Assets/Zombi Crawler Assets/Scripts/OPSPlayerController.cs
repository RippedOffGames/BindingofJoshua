using UnityEngine;
/*
Adriana Seda Pagan
Player Controller
Handles physics based player movement
*/
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 5f;
    [SerializeField]
    private float accelerationRate = 20f;
    [SerializeField]
    private float knockbackForce = 10.0f;

    private Rigidbody2D rb;
    private OPSPlayerHealth healthComponent;
    private Vector2 targetVelocity = Vector2.zero;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        healthComponent = GetComponent<OPSPlayerHealth>();

    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 inputVector = new Vector2(moveX, moveY).normalized;
        targetVelocity = inputVector * maxSpeed;
    }

    // Physics movement to get momentum feel
    void FixedUpdate()
    {
        if (targetVelocity != Vector2.zero)
        {
            rb.linearVelocity = Vector2.MoveTowards(rb.linearVelocity, targetVelocity, accelerationRate * Time.fixedDeltaTime);
        }
    }

    // Knockback player on collision with enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            healthComponent.Damage(10);
            Vector2 knockbackDirection = transform.position - collision.transform.position;
            rb.AddForce(knockbackDirection * knockbackForce * 5, ForceMode2D.Impulse);
        }
    }
}