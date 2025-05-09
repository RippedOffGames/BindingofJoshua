using UnityEngine;
using UnityEngine.SceneManagement;
// STATE PATTERN
public class SquareCommander : MonoBehaviour
{
    private ISquareMood currentMood;

    public void ChangeMood(ISquareMood newMood)
    {
        currentMood = newMood;
        currentMood.Activate(this);
    }

    public void SetSquareColor(Color moodColor)
    {
        GetComponent<SpriteRenderer>().color = moodColor;
    }

    void Start()
    {
        ChangeMood(new ChillMood());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("MainMenu");
        }
    }

}
