using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 2f;
    public Vector2 yRange = new Vector2(-1f, 1f); // vertical randomness

    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), 2f, spawnInterval);
    }

    void SpawnObstacle()
    {
        float randomY = Random.Range(yRange.x, yRange.y);
        Vector3 spawnPos = new Vector3(transform.position.x, randomY, 0);
        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
}
