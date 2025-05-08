using UnityEngine;

public class OrbCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D thing)
    {
        if (thing.CompareTag("Player"))
        {
            var s = ServiceLocator.Get<ScoreService>();
            var a = ServiceLocator.Get<SoundService>();

            s.AddOne();
            a.doSound();

            Destroy(gameObject);
        }
    }
}
