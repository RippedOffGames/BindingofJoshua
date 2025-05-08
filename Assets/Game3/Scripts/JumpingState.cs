//Deja Hang
//5/6/25

using UnityEngine;

public class JumpingState : IPlayerState
{
    //Methods
    public void Enter(PlayerMovement player)
    {
        player.PerformJump();
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
