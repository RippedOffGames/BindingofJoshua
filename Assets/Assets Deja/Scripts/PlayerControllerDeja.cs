using System.Collections;
using UnityEngine;

public class PlayerControllerDeja : MonoBehaviour
{
    public float health = 100f;
    public int damage = 10;
    public float speed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ApplyPowerUp(other.gameObject.tag);
        Destroy(other.gameObject); // Remove power-up after applying
    }

    void ApplyPowerUp(string powerUpTag)
    {
        IMovementStrategyDeja strategy = StrategyFactoryDeja.GetStrategy(powerUpTag);
        if (strategy != null)
        {
            speed = strategy.GetSpeed();
            health += strategy.GetHealthBoost();
            damage += strategy.GetDamageBoost();

            Debug.Log($"Power-up Applied! Speed: {speed}, Health: {health}, Damage: {damage}");
        }
    }

}
