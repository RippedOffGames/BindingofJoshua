//Deja Hang
//5/6/25
// STATE PATTERN IMPLEMENTATION
// Each of these represents a state the player can be in
using UnityEngine;

public class IdleState : IPlayerState
{
    //Methods
    public void Enter(PlayerMovement player)
    {
        player.animator.SetFloat("magnitude", 0);
    }

    public void HandleInput(PlayerMovement player)
    {
        if (player.IsJumpPressed() && player.CanJump())
        {
            player.TransitionToState(new JumpingState());
        }
        else if (player.GetHorizontal() != 0)
        {
            player.TransitionToState(new MovingState());
        }
    }


    public void Update(PlayerMovement player) { }

    public void Exit(PlayerMovement player) { }
}

