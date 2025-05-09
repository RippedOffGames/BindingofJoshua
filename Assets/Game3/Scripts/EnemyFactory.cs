//Deja Hang
//5/6/25
// FACTORY PATTERN
// Creates enemy prefabs based on a given type string

using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    // Variables
    public GameObject basicEnemyPrefab;
    public GameObject flyingEnemyPrefab;

    //Methods
    public GameObject CreateEnemy(string type)
    {
        switch (type)
        {
            case "Flying":
                return Instantiate(flyingEnemyPrefab);
            case "Basic":
            default:
                return Instantiate(basicEnemyPrefab);
        }
    }

}

