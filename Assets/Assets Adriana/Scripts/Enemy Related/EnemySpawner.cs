using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int spawnedGroupOfEnemeisCounter = 0;
    private EnemyFactory enemyFactory;
    private int minimumEnemiesToSpawn = 2;
    private int maximumEnemiesToSpawn = 7;
    
    private Vector3 CalculateSpawnPosition()
    {
        float maxX = 2.5f;
        float minX = -2.5f;
        float maxY = 4.5f;
        float minY = 4.5f;

        float xPosition = transform.position.x + Random.Range(minX, maxX);
        float yPosition = transform.position.y + Random.Range(minY, maxY);

        return new Vector3(xPosition, yPosition);
    }

    public void SpawnEnemy()
    {
        //Get the amount of enemies to spawn
        int enemiesToSpawn = Random.Range(minimumEnemiesToSpawn, maximumEnemiesToSpawn);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            //Enums are integers under the hood so this works
            EnemyFactory.EnemyType enemyType = (EnemyFactory.EnemyType) Random.Range(0, 1);

            GameObject enemy = enemyFactory.CreateEnemy(enemyType);

            Transform enemyTransform = enemy.GetComponent<Transform>();
            enemyTransform.position = CalculateSpawnPosition();
            enemy.SetActive(true);

        }
    }
}
