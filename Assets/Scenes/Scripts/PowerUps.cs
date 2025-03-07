using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType { Speed, Health, FireRate }

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpType powerUpType;
    [SerializeField] private float effectAmount = 1.5f; // Increase by 1.5x
    [SerializeField] private float duration = 5f; // Effect duration

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                switch (powerUpType)
                {
                    case PowerUpType.Speed:
                        player.StartCoroutine(player.ApplySpeedBoost(effectAmount, duration));
                        break;
                    case PowerUpType.Health:
                        player.IncreaseHealth(effectAmount);
                        break;
                    case PowerUpType.FireRate:
                        player.StartCoroutine(player.ApplyFireRateBoost(effectAmount, duration));
                        break;
                }
                Destroy(gameObject);
            }
        }
    }
}
