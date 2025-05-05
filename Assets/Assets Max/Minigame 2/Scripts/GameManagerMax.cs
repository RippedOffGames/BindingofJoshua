using UnityEngine;

public class GameManagerMax : MonoBehaviour
{
    public ScoreService scoreThing;
    public SoundService soundThing;

    void Awake()
    {
        // this part sets up access for the score and sound
        ServiceLocator.ClearAll();
        ServiceLocator.Register(scoreThing);
        ServiceLocator.Register(soundThing);
    }
}