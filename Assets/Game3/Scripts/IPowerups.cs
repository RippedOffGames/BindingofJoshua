//Deja Hang
//5/6/25
// STRATEGY PATTERN INTERFACE
// Defines the behavior contract for all power-up types

using UnityEngine;

public interface IPowerups
{
    public void Collect();
    public float GetSpeed();
    public int GetJump();
    public int GetDamage(); 
}
