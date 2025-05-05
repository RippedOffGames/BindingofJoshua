using UnityEngine;
/*
Adriana Seda Pagan
Enemy Health Component
*/
public class OPSEnemyHealth : MonoBehaviour
{
    private int enemyMaxHealth = 100;
    private int enemyCurrentHealth;

    void Awake()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

    public void EnemyDamage(int amount)
    {
        enemyCurrentHealth -= amount;
        if (enemyCurrentHealth <= 0)
            EnemyDie();
    }
    // For future use if I want to heal player after x waves
    public void Heal(int amount)
    {
        enemyCurrentHealth = Mathf.Clamp(enemyCurrentHealth + amount, 0, enemyMaxHealth);
    }

    private void EnemyDie()
    {
        Destroy(gameObject);
        OPSGameManager.Instance.EnemyDied();
    }

}
