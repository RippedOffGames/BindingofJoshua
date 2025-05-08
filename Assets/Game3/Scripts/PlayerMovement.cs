//Deja Hang
//5/6/25

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    //Variables
    public Rigidbody2D rb;
    public Animator animator;
    public float moveSpeed = 5f;
    public float jumpHeight = 5f;
    public int damageMultiplier = 1;
    public int maxJumps = 2;
    int jumpsRemaining;
    float horizontalMovement;
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;
    public float baseGravity = 2;
    public float maxFallSpeed = 18f;
    public float fallSpeedMultiplier = 2f;
    private IPlayerState currentState;
    public float HorizontalInput;
    private bool jumpPressed;
        

    //Methods
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentState = new IdleState();
        currentState.Enter(this);
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y);
        GroundCheck();
        Gravity();
        currentState.HandleInput(this);
        currentState.Update(this);

        animator.SetFloat("yVelocity", rb.linearVelocity.y);
        animator.SetFloat("magnitude", rb.linearVelocity.magnitude);
    }

    public void TransitionToState(IPlayerState newState)
    {
        currentState.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }



    public void Gravity()
    {
        if(rb.linearVelocity.y < 0)
        {
            rb.gravityScale = baseGravity * fallSpeedMultiplier;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -maxFallSpeed));

        }
        else
        {
            rb.gravityScale = baseGravity;
        }
    }

    public float GetHorizontal() => horizontalMovement;

    public bool IsJumpPressed() => jumpPressed;

    public bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer);
    }

    public bool CanJump() => jumpsRemaining > 0;

    public void PerformJump()
    {
        if (jumpsRemaining > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
            jumpsRemaining--;
            animator.SetTrigger("Jump");
        }
    }


    public void MoveCharacter()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y);
    }


    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (jumpsRemaining > 0)
        {
            if (context.performed)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
                jumpsRemaining--;
                animator.SetTrigger("Jump");
            }
            else if (context.canceled)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
                jumpsRemaining--;
                animator.SetTrigger("Jump");
            }
        }
    }



    public void GroundCheck()
    {
        if(Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            jumpsRemaining = maxJumps;
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position , groundCheckSize);
    }

    public void ApplyPowerup(IPowerups powerup)
    {
        powerup.Collect();

        if (powerup.GetSpeed() > 0f)
            moveSpeed = powerup.GetSpeed();

        if (powerup.GetJump() > 0)
        {
            maxJumps = powerup.GetJump();
            jumpsRemaining = maxJumps;
        }

        if (powerup.GetDamage() > 0)
        {
            damageMultiplier = powerup.GetDamage(); // use this in bow/bullet logic
        }
    }
}
