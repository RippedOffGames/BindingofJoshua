using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerDeja : MonoBehaviour
{
    [SerializeField]
    private GameObject[] powerUps; // Assign different power-up prefabs in the Inspector
    [SerializeField]
    private int powerupsPerType = 5; // Number of each power-up type to spawn
    private Vector2 spawnAreaSize = new Vector2(50, 50);
    private float powerUpSpawnInterval = 10f; // Time between spawns

    void Start()
    {
        SpawnPowerUps();
        StartCoroutine(SpawnPowerUpsPeriodically());
    }

    void SpawnPowerUps()
    {
        foreach (GameObject powerUp in powerUps)
        {
            for (int i = 0; i < powerupsPerType; i++)
            {
                Vector3 randomPosition = GetRandomPosition();
                Instantiate(powerUp, randomPosition, Quaternion.identity);
            }
        }
    }

    IEnumerator SpawnPowerUpsPeriodically()
    {
        while (true)
        {
            yield return new WaitForSeconds(powerUpSpawnInterval);

            // Randomly choose a power-up to spawn
            GameObject powerUpToSpawn = powerUps[Random.Range(0, powerUps.Length)];
            Vector3 randomPosition = GetRandomPosition();
            Instantiate(powerUpToSpawn, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
        float y = 0; // Adjust if power-ups need to float
        float z = Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2);
        return new Vector3(x, y, z);
    }
}
