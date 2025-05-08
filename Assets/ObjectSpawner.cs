//Deja Hang
//5/6/25

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectSpawner : MonoBehaviour
{
    // Variables
    public enum ObjectType { Damagepowerup, Jumppowerup, Speedpowerup, Enemy }

    public Tilemap tilemap;
    public GameObject[] objectPrefabs;
    public float enemyProbability = 0.1f;
    public float DamageProbability = 0.1f;
    public float JumpProbability = 0.1f;
    public float SpeedProbability = 0.1f;
    public int maxObjects = 3;
    public float powerupLifetime = 10f;
    public float spawnInterval = 0.5f;
    public EnemyFactory enemyFactory;
    public float flyingEnemyHeightOffset = 2.5f;

    private List<Vector3> groundSpawnPositions = new List<Vector3>();
    private List<Vector3> flyingSpawnPositions = new List<Vector3>();
    private List<GameObject> spawnObjects = new List<GameObject>();
    private bool isSpawning = false;

    //Methods
    void Start()
    {
        GatherValidPositions();
        StartCoroutine(SpawnObjectsIfNeeded());
    }

    void Update()
    {
        if (!isSpawning && ActiveObjectCount() < maxObjects)
            StartCoroutine(SpawnObjectsIfNeeded());
    }

    private int ActiveObjectCount()
    {
        spawnObjects.RemoveAll(item => item == null);
        return spawnObjects.Count;
    }

    private IEnumerator SpawnObjectsIfNeeded()
    {
        isSpawning = true;
        while (ActiveObjectCount() < maxObjects)
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnInterval);
        }
        isSpawning = false;
    }

    private bool PositionHasObject(Vector3 pos)
    {
        return spawnObjects.Any(o => o && Vector3.Distance(o.transform.position, pos) < 1f);
    }

    private ObjectType RandomObjectType()
    {
        float r = Random.value;
        if (r <= enemyProbability) return ObjectType.Enemy;
        if (r <= enemyProbability + DamageProbability) return ObjectType.Damagepowerup;
        if (r <= enemyProbability + DamageProbability + SpeedProbability) return ObjectType.Speedpowerup;
        return ObjectType.Jumppowerup;
    }

    private void SpawnObject()
    {
        ObjectType type = RandomObjectType();
        bool isFlying = false;
        string subtype = "";
        List<Vector3> sourceList;

        if (type == ObjectType.Enemy)
        {
            isFlying = Random.value < 0.5f;
            subtype = isFlying ? "Flying" : "Basic";
            sourceList = isFlying ? flyingSpawnPositions : groundSpawnPositions;
        }
        else
        {
            sourceList = groundSpawnPositions;
        }

        if (sourceList.Count == 0) return;

        Vector3 spawnPos = Vector3.zero;
        bool found = false;
        var positions = new List<Vector3>(sourceList);

        while (!found && positions.Count > 0)
        {
            int idx = Random.Range(0, positions.Count);
            Vector3 candidate = positions[idx];

            if (!PositionHasObject(candidate + Vector3.left) && !PositionHasObject(candidate + Vector3.right))
            {
                spawnPos = candidate;
                found = true;
            }

            positions.RemoveAt(idx);
        }

        if (!found) return;

        GameObject go = null;

        if (type == ObjectType.Enemy && enemyFactory != null)
        {
            go = enemyFactory.CreateEnemy(subtype);

            Vector3 actualSpawnPos = spawnPos;
            if (subtype == "Flying")
                actualSpawnPos += new Vector3(0, flyingEnemyHeightOffset, 0);

            go.transform.position = actualSpawnPos;
        }
        else
        {
            go = Instantiate(objectPrefabs[(int)type], spawnPos, Quaternion.identity);
            StartCoroutine(DestroyObjectAfterTime(go, powerupLifetime));
        }

        if (go != null)
            spawnObjects.Add(go);
    }

    public void GatherValidPositions()
    {
        groundSpawnPositions.Clear();
        flyingSpawnPositions.Clear();

        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] tiles = tilemap.GetTilesBlock(bounds);
        Vector3 worldStart = tilemap.CellToWorld(new Vector3Int(bounds.xMin, bounds.yMin, 0));

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase t = tiles[x + y * bounds.size.x];
                if (t != null)
                {
                    Vector3 basePos = worldStart + new Vector3(x + 0.5f, y + 0.5f, 0);
                    groundSpawnPositions.Add(basePos + Vector3.up * 1.5f);
                    flyingSpawnPositions.Add(basePos + Vector3.up * 4f);
                }
            }
        }
    }

    private IEnumerator DestroyObjectAfterTime(GameObject obj, float t)
    {
        yield return new WaitForSeconds(t);
        if (obj)
        {
            spawnObjects.Remove(obj);
            Destroy(obj);
        }
    }
}
