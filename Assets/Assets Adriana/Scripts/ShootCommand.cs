using UnityEngine;

public class ShootCommand : ICommand
{
    private PlayerControllerAdriana player;
    private Vector2 direction;

    public ShootCommand(PlayerControllerAdriana player, Vector2 dir)
    {
        this.player = player;
        this.direction = dir;
    }

    public void Execute()
    {
        player.Shoot(direction.x, direction.y);
    }
}