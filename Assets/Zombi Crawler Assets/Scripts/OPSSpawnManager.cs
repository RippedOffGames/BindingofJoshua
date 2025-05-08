using UnityEngine;

public class OPSSpawnManager : MonoBehaviour
{
    [Header("Spawning Settings")]
    public GameObject enemyPrefab;

    // Optional: assign specific spawn points via the Inspector.
    public Transform[] spawnPoints;

    // If no spawn points are provided, use this random area (20x20 default).
    public Vector2 spawnArea = new Vector2(20f, 20f);

    public void SpawnEnemy()
    {
        Vector3 spawnPosition;
        if (spawnPoints != null && spawnPoints.Length > 0)
        {
            // Choose a random spawn point.
            Transform chosenPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            spawnPosition = chosenPoint.position;
        }
        else
        {
            // Choose a random position within the defined rectangle.
            float halfWidth = spawnArea.x / 2f;
            float halfHeight = spawnArea.y / 2f;
            spawnPosition = new Vector3(
                transform.position.x + Random.Range(-halfWidth, halfWidth),
                transform.position.y + Random.Range(-halfHeight, halfHeight),
                transform.position.z
            );
        }

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
