using UnityEngine;

public class SoundService : MonoBehaviour, IService
{
    public AudioClip beep;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void doSound()
    {
        if (beep != null)
        {
            source.PlayOneShot(beep);
        }
    }
}
