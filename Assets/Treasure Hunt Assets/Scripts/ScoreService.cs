using TMPro;
using UnityEngine;

// this class keeps track of score and updates the UI appropriately 

public class ScoreService : MonoBehaviour, IService
{
    public int myScore = 0;
    public TextMeshProUGUI scoreUI;

    public void AddOne()
    {
        myScore += 1;
        if (scoreUI != null)
        {
            scoreUI.text = "Score: " + myScore;
        }
    }
}
