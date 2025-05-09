//Deja Hang
//5/6/25
// STATE PATTERN IMPLEMENTATION
// Each of these represents a state the player can be in
using UnityEngine;

public class JumpingState : IPlayerState
{
    //Methods
    public void Enter(PlayerMovement player)
    {
        player.PerformJump();
        player.ClearJumpInput();
    }


    public void HandleInput(PlayerMovement player) { }

    public void Update(PlayerMovement player)
    {
        if (player.IsGrounded())
        {
            player.TransitionToState(new IdleState());
        }
    }

    public void Exit(PlayerMovement player) { }
}
