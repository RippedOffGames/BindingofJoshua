using UnityEngine;

public class ChillMood : ISquareMood
{
    public void Activate(SquareCommander square)
    {
        square.SetSquareColor(Color.white); // default chill
        square.transform.localScale = Vector3.one;
    }
}
