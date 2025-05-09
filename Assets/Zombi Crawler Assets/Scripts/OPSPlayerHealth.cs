using UnityEngine;
/*
Adriana Seda Pagan
Player Health Component
An observer of the rampage mode event, changes behavior
to give player invulnerability when we are in rampage mode
*/
public class OPSPlayerHealth : MonoBehaviour, IRampageObserver
{
    private int maxHealth = 100;
    private int currentHealth;
    public bool RampageActive { get; set; }

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void OnEnable()
    {
        // Subscribe to rampage mode event
        OPSGameManager.Instance.OnRampageModeChanged += HandleRampageModeChanged;

    }
    void OnDisable()
    {
        if (OPSGameManager.Instance != null)
            OPSGameManager.Instance.OnRampageModeChanged -= HandleRampageModeChanged;
    }
    public void HandleRampageModeChanged(bool isActive)
    {
        RampageActive = isActive;
    }
    public void Damage(int amount)
    {
        if (RampageActive)
        {
            Debug.Log("Player is invincible during rampage. No damage taken.");
            return;
        }
        currentHealth -= amount;
        Debug.Log(gameObject.name + " took " + amount + " damage. Current health: " + currentHealth);
        if (currentHealth <= 0)
            Die();
    }

    // For possible future use
    public void Heal(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }

    private void Die()
    {
        Destroy(gameObject);
        OPSGameManager.Instance.PlayerDied();
    }
}
