using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float baseSpeed = 5f;
    private float baseFireRate = 0.5f;
    private float currentSpeed;
    private float currentFireRate;
    private int health = 100;

    private void Start()
    {
        currentSpeed = baseSpeed;
        currentFireRate = baseFireRate;
    }

    public IEnumerator ApplySpeedBoost(float multiplier, float duration)
    {
        currentSpeed *= multiplier;
        yield return new WaitForSeconds(duration);
        currentSpeed = baseSpeed;
    }

    public IEnumerator ApplyFireRateBoost(float multiplier, float duration)
    {
        currentFireRate /= multiplier; // Faster shooting = decrease delay
        yield return new WaitForSeconds(duration);
        currentFireRate = baseFireRate;
    }

    public void IncreaseHealth(float amount)
    {
        health += (int)amount;
        if (health > 100) health = 100; // Cap at max health
    }
}
