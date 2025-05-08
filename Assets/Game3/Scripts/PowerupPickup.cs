//Deja Hang
//5/6/25

using UnityEngine;

public class PowerupPickup : MonoBehaviour
{
    //Methods
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            string tag = gameObject.tag;
            IPowerups powerup = PowerupFactory.GetPowerup(tag);

            if (powerup != null)
            {
                player.ApplyPowerup(powerup);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Powerup not recognized for tag: " + tag);
            }
        }
    }
}