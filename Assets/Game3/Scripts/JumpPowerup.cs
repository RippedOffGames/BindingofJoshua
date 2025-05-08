//Deja Hang
//5/6/25

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerup : IPowerups
{
    //Methods
    public void Collect()
    {

    }

    public float GetSpeed() => 0f;         // No speed change
    public int GetJump() => 8;             // Double jump
    public int GetDamage() => 0;
}
