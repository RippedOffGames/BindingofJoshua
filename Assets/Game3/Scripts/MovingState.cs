//Deja Hang
//5/6/25
// STATE PATTERN IMPLEMENTATION
// Each of these represents a state the player can be in
using UnityEngine;

public class MovingState : IPlayerState
{
    //Methods
    public void Enter(PlayerMovement player)
    {
        player.animator.SetFloat("magnitude", Mathf.Abs(player.HorizontalInput));
    }

    public void HandleInput(PlayerMovement player)
    {
        if (player.IsJumpPressed() && player.CanJump())
        {
            player.TransitionToState(new JumpingState());
        }
    }


    public void Update(PlayerMovement player)
    {
        player.MoveCharacter();
    }

    public void Exit(PlayerMovement player) { }
}

