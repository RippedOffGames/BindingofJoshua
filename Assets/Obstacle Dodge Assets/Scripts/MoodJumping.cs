using UnityEngine;

public class MoodJumping : ISquareMood
{
    public void Activate(SquareCommander square)
    {
        square.SetSquareColor(new Color(0.2f, 1f, 0.2f)); // cool color that I like, MINT GREEN!
        Rigidbody2D rb = square.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 6f); // basic upward force
        }
    }
}
