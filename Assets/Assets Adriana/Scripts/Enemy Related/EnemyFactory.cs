using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyPrefabList;

    public enum EnemyType
    {
        Trap,
        Ranged
    }

    public GameObject CreateEnemy(EnemyType enemyType)
    {
        GameObject enemyPrefab;

        switch (enemyType)
        {
            case EnemyType.Trap:
                enemyPrefab = enemyPrefabList[0]; 
                break;
            case EnemyType.Ranged:
                enemyPrefab = enemyPrefabList[1];
                break;
            default:
                enemyPrefab = null;
                break;
        }
        if (enemyPrefab != null)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            return enemy;
        }
        return null;
    }



}
