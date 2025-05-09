//Deja Hang
//5/6/25
// Inherits and uses the enemy interface
using UnityEngine;

public class BasicEnemy : Game3Enemy
{
    // Variables
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private bool isGrounded;

    //Methods

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);
    }
}
