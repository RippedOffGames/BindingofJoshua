using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Max Schmit 2/28/2025
public class BulletControllerMax : MonoBehaviour
{
    // VARS
    public float lifeTime; // this will be the lifetime of the bullet

    // METHODS


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DeathDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
