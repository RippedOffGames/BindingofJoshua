using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementStrategyDeja
{
    float GetSpeed();
    int GetHealthBoost();  // Add health restoration
    int GetDamageBoost();  // Add damage increase
}

