using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUpDeja : IMovementStrategyDeja
{
    public float GetSpeed() => 20.0f; // Increased speed
    public int GetHealthBoost() => 0; // No health boost
    public int GetDamageBoost() => 0; // No damage increase
}

