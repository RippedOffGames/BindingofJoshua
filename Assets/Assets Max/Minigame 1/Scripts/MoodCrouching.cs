using UnityEngine;

public class MoodCrouching : ISquareMood
{
    public void Activate(SquareCommander square)
    {
        square.SetSquareColor(new Color(0.2f, 0.5f, 1f)); // bluish because I like blue
        square.transform.localScale = new Vector3(1f, 0.5f, 1f); // shrink
    }
}
