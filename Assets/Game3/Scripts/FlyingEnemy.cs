//Deja Hang
//5/6/25
// Inherits and uses the enemy interface

using UnityEngine;

public class FlyingEnemy : Game3Enemy
{
    // Variables
    [Header("Flight Settings")]
    public float floatSpeed = 2f;  
    public float floatHeight = 1f;    

    private Rigidbody2D rb;
    private Vector2 basePosition;

    //Methods
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        basePosition = rb.position;
    }

    void FixedUpdate()
    {
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        Vector2 nextPos = new Vector2(basePosition.x, basePosition.y + yOffset);

        rb.MovePosition(nextPos);
    }
}

