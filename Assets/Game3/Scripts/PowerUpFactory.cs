//Deja Hang
//5/6/25
// FACTORY + STRATEGY PATTERN
// Returns the correct strategy object based on tag
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PowerupFactory
{
    //Methods
    public static IPowerups GetPowerup(string tag)
    {
        IPowerups strategy = null;

        switch (tag)
        {
            case "DamagePowerUp":
                strategy = new DamagePowerup();
                break;
            case "SpeedPowerUp":
                strategy = new SpeedPowerup();
                break;
            case "JumpPowerUp":
                strategy = new JumpPowerup();
                break;
            default:
                strategy = new DamagePowerup();
                break;
        }
        return strategy;
    }
}
