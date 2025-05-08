//Deja Hang
//5/6/25


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

