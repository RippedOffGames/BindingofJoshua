using TMPro; // <-- Add this
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerMax : MonoBehaviour
{
    public ScoreService scoreThing;
    public SoundService soundThing;

    public float gameDuration = 30f;
    private float timer;
    public TextMeshProUGUI timerText;
    private bool gameActive = true;

    void Awake()
    {
        ServiceLocator.ClearAll();
        ServiceLocator.Register(scoreThing);
        ServiceLocator.Register(soundThing);
        timer = gameDuration;
    }

    void Update()
    {
        if (!gameActive) return;

        timer -= Time.deltaTime;
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Ceil(timer);
        }

        if (timer <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameActive = false;
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.GetComponent<SeekerController>().enabled = false;
        }

        Debug.Log("Game Over! Score: " + scoreThing.myScore);
        SceneManager.LoadScene("MainMenu");
    }

}
