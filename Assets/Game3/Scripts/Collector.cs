//Deja Hang
//5/6/25

using UnityEngine;

public class Collector : MonoBehaviour
{
    //Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPowerups powerUps = collision.GetComponent<IPowerups>();
        if(powerUps != null)
        {
            powerUps.Collect();
        }
    }
}
