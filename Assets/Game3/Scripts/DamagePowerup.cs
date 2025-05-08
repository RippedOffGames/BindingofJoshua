//Deja Hang
//5/6/25

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerup : IPowerups
{
    //Methods
    public void Collect()
    {
    }

    public float GetSpeed() => 0f;         
    public int GetJump() => 0;             
    public int GetDamage() => 2;
}
