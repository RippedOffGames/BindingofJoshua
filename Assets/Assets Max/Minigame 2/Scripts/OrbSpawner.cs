using UnityEngine;

public class BeaconOrbSpawner : MonoBehaviour
{
    public GameObject orbPrefab;
    public int spawnLimit = 10;
    public float spawnRangeX = 8f;
    public float spawnRangeY = 4f;

    void Start()
    {
        for (int i = 0; i < spawnLimit; i++)
        {
            float randX = Random.Range(-spawnRangeX, spawnRangeX);
            float randY = Random.Range(-spawnRangeY, spawnRangeY);
            Vector2 spawnPos = new Vector2(randX, randY);

            Instantiate(orbPrefab, spawnPos, Quaternion.identity);
        }
    }
}
