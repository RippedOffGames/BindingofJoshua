using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 moveByCoordinates;
    Vector3 positionBeforeAutoMove;
    private bool timeToMoveCamera = false;
    GameObject enemySpawner;
    EnemySpawner spawnerScript;

    private void Awake()
    {
        enemySpawner = transform.GetChild(0).gameObject;
    }
    private void Update()
    {
        MoveCamera();
    }
    public void BeginCameraMovement(Collider2D doorCollider, int colliderCounter)
    {
        if (doorCollider.name.Equals("Left Door") && (colliderCounter == 0))
        {
            moveByCoordinates = new Vector3(-11, 0, 0);
        }
        else if (doorCollider.name.Equals("Right Door") && (colliderCounter == 0))
        {
            moveByCoordinates = new Vector3(11, 0, 0);
        }
        else if (doorCollider.name.Equals("Top Door") && (colliderCounter == 0))
        {
            moveByCoordinates = new Vector3(0, 7f, 0);
        }
        else if (doorCollider.name.Equals("Bottom Door") && (colliderCounter == 0))
        {
            moveByCoordinates = new Vector3(0, -7f, 0);
        }
        positionBeforeAutoMove = transform.position;
        timeToMoveCamera = true;
        

    }

    public void MoveCamera()
    {
        if (timeToMoveCamera)
        {
            transform.position = Vector3.MoveTowards(transform.position, positionBeforeAutoMove + moveByCoordinates, Time.deltaTime * 3);
            if (transform.position == positionBeforeAutoMove + moveByCoordinates)
            {
                timeToMoveCamera = false;
                spawnerScript = enemySpawner.GetComponent<EnemySpawner>();
                spawnerScript.SpawnEnemy();
            }
        }
    }
}
