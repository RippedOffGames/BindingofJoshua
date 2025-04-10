using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerControllerAdriana player;

    void Start()
    {
        player = GetComponent<PlayerControllerAdriana>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (!player.IsInputDisabled())
        {
            if (moveInput != Vector2.zero)
            {
                ICommand moveCommand = new MoveCommand(player, moveInput);
                moveCommand.Execute();
            }

            Vector2 shootInput = new Vector2(Input.GetAxis("ShootHorizontal"), Input.GetAxis("ShootVertical"));
            if (shootInput != Vector2.zero && Time.time > player.LastFire + player.FireDelay)

            {
                ICommand shootCommand = new ShootCommand(player, shootInput.normalized);
                shootCommand.Execute();
                player.LastFire = Time.time;
            }
        }
    }
}