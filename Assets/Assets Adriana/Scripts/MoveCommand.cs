using UnityEngine;

public class MoveCommand : ICommand
{
    private PlayerControllerAdriana player;
    private Vector2 direction;

    public MoveCommand(PlayerControllerAdriana player, Vector2 dir)
    {
        this.player = player;
        this.direction = dir;
    }

    public void Execute()
    {
        player.Move(direction);
    }
}