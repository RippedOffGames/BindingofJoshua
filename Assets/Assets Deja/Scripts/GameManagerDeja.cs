using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManagerDeja : MonoBehaviour
{
    [SerializeField]
    private GameObject[] powerUps; // Assign power-up prefabs in Inspector
    [SerializeField]
    private int powerupsPerType = 5; // Number of each type to spawn
    [SerializeField]
    private float powerUpSpawnInterval = 10f; // Time between spawns
    public Tilemap tilemap;

    private List<Vector2> validSpawnPositions = new List<Vector2>();

    void Start()
    {
        GetValidTilePositions();
        SpawnPowerUps();
        StartCoroutine(SpawnPowerUpsPeriodically());
    }

    void GetValidTilePositions()
    {
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                TileBase tile = tilemap.GetTile(new Vector3Int(x, y, 0));
                if (tile != null)
                {
                    Vector3 worldPosition = tilemap.CellToWorld(new Vector3Int(x, y, 0)) + new Vector3(0.5f, 0.5f, 0);
                    validSpawnPositions.Add(worldPosition);
                }
            }
        }
    }

    void SpawnPowerUps()
    {
        foreach (GameObject powerUp in powerUps)
        {
            for (int i = 0; i < powerupsPerType; i++)
            {
                if (validSpawnPositions.Count == 0) return;

                int randomIndex = Random.Range(0, validSpawnPositions.Count);
                Vector3 spawnPosition = validSpawnPositions[randomIndex];

                Instantiate(powerUp, spawnPosition, Quaternion.identity);
            }
        }
    }

        IEnumerator SpawnPowerUpsPeriodically()
    {
        while (true)
        {
            yield return new WaitForSeconds(powerUpSpawnInterval);

            GameObject powerUpToSpawn = powerUps[Random.Range(0, powerUps.Length)];
            Vector3 spawnPosition = GetRandomGridPosition();
            Instantiate(powerUpToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomGridPosition()
    {
        if (validSpawnPositions.Count == 0) return Vector3.zero;

        int randomIndex = Random.Range(0, validSpawnPositions.Count);
        Vector2 gridPosition = validSpawnPositions[randomIndex];
        return new Vector3(gridPosition.x, 0, gridPosition.y); // Adjust Y if needed
    }
}
