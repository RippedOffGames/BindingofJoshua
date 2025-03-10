using UnityEngine;

public class DamagePowerUpDeja : IMovementStrategyDeja
{
    public float GetSpeed() => 12.0f; // Slightly increased speed
    public int GetHealthBoost() => 0; // No health boost
    public int GetDamageBoost() => 10; // Increases damage by 10
}

