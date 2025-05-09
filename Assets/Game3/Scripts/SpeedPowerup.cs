//Deja Hang
//5/6/25
// STRATEGY PATTERN IMPLEMENTATION
// One concrete strategy for increasing speed
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpeedPowerup : IPowerups
{
    //Methods
    public void Collect()
    {
    }

    public float GetSpeed() => 9.0f;      
    public int GetJump() => 0;           
    public int GetDamage() => 0;
}
