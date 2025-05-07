using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 5f;
    private bool hasScored = false;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (!hasScored && transform.position.x < -1.5f) // or your player's x - a buffer
        {
            hasScored = true;
            ScoreManager scoreMgr = FindObjectOfType<ScoreManager>();
            if (scoreMgr != null)
            {
                scoreMgr.AddPoint();
            }
        }

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
