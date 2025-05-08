//Deja Hang
//5/6/25

using UnityEngine;

public interface IBullet
{
    // Variables
    void OnTriggerEnter2D(Collider2D collision);
    void Shoot(Vector3 direction);
}

