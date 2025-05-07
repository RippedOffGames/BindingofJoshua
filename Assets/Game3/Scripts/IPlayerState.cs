//Deja Hang
//5/6/25

using UnityEngine;

public interface IPlayerState
{
    //Methods
    void Enter(PlayerMovement player);
    void HandleInput(PlayerMovement player);
    void Update(PlayerMovement player);
    void Exit(PlayerMovement player);
}
