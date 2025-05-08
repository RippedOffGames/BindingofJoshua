//Deja Hang
//5/6/25

using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    //Variables
    public GameObject bulletPrefab;
    public float bulletSpeed = 50f;

    //Methods
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 shootDirection = (mousePosition - transform.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = shootDirection * bulletSpeed;



        Destroy(bullet, 2f);
    }
}
