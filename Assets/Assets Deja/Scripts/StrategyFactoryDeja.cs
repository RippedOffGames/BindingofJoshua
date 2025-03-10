using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategyFactoryDeja
{
    public static IMovementStrategyDeja GetStrategy(string powerUpTag)
    {
        IMovementStrategyDeja strategy = null;

        switch (powerUpTag)
        {
            case "SpeedPowerUp":
                strategy = new SpeedPowerUpDeja();
                break;
            case "HealthPowerUp":
                strategy = new HealthPowerUpDeja();
                break;
            case "DamagePowerUp":
                strategy = new DamagePowerUpDeja();
                break;
            default:
                strategy = new SpeedPowerUpDeja();
                break;
        }

        return strategy;
    }
}
