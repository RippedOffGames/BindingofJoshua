using UnityEngine;
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
}
