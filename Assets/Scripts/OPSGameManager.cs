using UnityEngine;
using System;
using System.Collections;
/*
Adriana Seda Pagan
Game Manager Component

Handles enemy wave behavior and rampage mode
Class uses the observer pattern but through C# events
meaning the class declares an event and other classes subscribe to the event
meaning they want to be notified when an Action occurs, in this case when IsRampageMode
is set to true
*/
public class OPSGameManager : MonoBehaviour
{
    //Properties for public getter
    public static OPSGameManager Instance { get; private set; }
    public bool IsRampageActive { get; private set; } = false;

    private int currentWave = 0;
    private int initialEnemyCount = 5;
    [SerializeField]
    private float maxSpawnDelay = 3f;
    [SerializeField]
    private float minSpawnDelay = 1f;
    [SerializeField]
    private int maxBurstCount = 5;

    private int currentWaveEnemyCount;
    private int enemiesToSpawn;
    private int enemiesAlive;

    [SerializeField]
    private OPSSpawnManager spawnManager;

    private float rampageDuration = 10f;
    private int rampageCharges = 0;
    public event Action<bool> OnRampageModeChanged;


    //Singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        currentWaveEnemyCount = initialEnemyCount;
        StartNextWave();
    }

    void Update()
    {
        // Handles when to spawn next wave
        if (enemiesToSpawn <= 0 && enemiesAlive <= 0)
        {
            Debug.Log("Wave " + currentWave + " complete.");
            
            // Add a rampage charge after 5 waves completed
            if (currentWave % 5 == 0)
            {
                AddRampageCharge();
            }

            StartNextWave();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryActivateRampage();
        }

    }

    void StartNextWave()
    {
        currentWave++;
        // For waves beyond the first, add 1–3 extra enemies
        if (currentWave > 1)
        {
            currentWaveEnemyCount += UnityEngine.Random.Range(1, 4);
        }
        enemiesToSpawn = currentWaveEnemyCount;
        Debug.Log("Starting Wave " + currentWave + " with " + currentWaveEnemyCount + " enemies.");
        StartCoroutine(SpawnEnemiesInWave());
    }

    IEnumerator SpawnEnemiesInWave()
    {
        int waveTotalEnemies = currentWaveEnemyCount;
        while (enemiesToSpawn > 0)
        {
            // Calculate a progress ratio (0 at wave start, 1 when all enemies spawned)
            float progress = (waveTotalEnemies - enemiesToSpawn) / (float)waveTotalEnemies;

            // Determine burst spawn count that ramps up from 1 to maxBurstCount
            int burstCount = Mathf.RoundToInt(Mathf.Lerp(1, maxBurstCount, progress));
            burstCount = Mathf.Clamp(burstCount, 1, maxBurstCount);
            burstCount = Mathf.Min(burstCount, enemiesToSpawn);

            // Spawn a burst of enemies
            for (int i = 0; i < burstCount; i++)
            {
                spawnManager.SpawnEnemy();
                enemiesToSpawn--;
                enemiesAlive++;
            }

            // Interpolate delay so bursts happen more frequently as the wave progresses
            float spawnDelay = Mathf.Lerp(maxSpawnDelay, minSpawnDelay, progress);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void EnemyDied()
    {
        enemiesAlive--;
    }
 
    public void AddRampageCharge()
    {
        rampageCharges++;
        Debug.Log("Rampage charge added. Total rampage charges: " + rampageCharges);
    }


    public void TryActivateRampage()
    {
        if (IsRampageActive)
        {
            Debug.Log("Rampage mode is already active.");
            return;
        }
        if (rampageCharges <= 0)
        {
            Debug.Log("No rampage charges available.");
            return;
        }

        rampageCharges--;
        StartCoroutine(RampageRoutine());
    }


    IEnumerator RampageRoutine()
    {
        IsRampageActive = true;
        OnRampageModeChanged.Invoke(IsRampageActive);
        Debug.Log("Rampage mode activated for " + rampageDuration + " seconds.");
        yield return new WaitForSeconds(rampageDuration);
        IsRampageActive = false;
        OnRampageModeChanged.Invoke(IsRampageActive);
        Debug.Log("Rampage mode deactivated.");
    }
}

