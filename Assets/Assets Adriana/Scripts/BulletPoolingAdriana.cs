using System.Collections.Generic;
using UnityEngine;

public class BulletPoolingAdriana : MonoBehaviour
{
    public static BulletPoolingAdriana Instance;

    public GameObject bulletPrefab;
    public int poolSize = 20;

    private Queue<GameObject> bulletPool = new Queue<GameObject>();

    private void Awake() //  I uh used some AI help for this code..........
    {
        Instance = this;
        InitializePool();
    }

    private void InitializePool() //  This code too...... :
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet()
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab);
            return bullet;
        }
    }

    public void ReturnBullet(GameObject bullet)
    {
        if (bullet.activeSelf) // Ensure it's only deactivated once
        {
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
            Debug.Log("Bullet returned to pool: " + bullet.name);
        }
        else
        {
            Debug.LogWarning("Attempted to return an inactive bullet: " + bullet.name);
        }
    }

}
