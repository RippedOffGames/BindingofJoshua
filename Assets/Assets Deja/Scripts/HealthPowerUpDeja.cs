using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUpDeja : IMovementStrategyDeja
{
    public float GetSpeed() => 10.0f; // Normal speed
    public int GetHealthBoost() => 25; // Restores 25 health
    public int GetDamageBoost() => 0; // No damage increase
}

