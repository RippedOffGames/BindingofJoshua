using UnityEngine;
using UnityEngine.UI;

public class HealthBarObserver : MonoBehaviour, IObserver
{
    public PlayerHealth playerHealth;
    public Image healthBar;

    void Start()
    {
        playerHealth.RegisterObserver(this);
    }

    public void OnNotify(string eventType)
    {
        if (eventType == "HealthChanged")
        {
            healthBar.fillAmount = playerHealth.currentHealth / playerHealth.maxHealth;
        }
    }

    void OnDestroy()
    {
        playerHealth.UnregisterObserver(this);
    }
}

