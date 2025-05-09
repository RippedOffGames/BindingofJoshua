using UnityEngine;

public class MoodButtonManager : MonoBehaviour
{
    public SquareCommander targetSquare;
    // COMMAND PATTERN
    // Perform method calls changeMood on squarecommander which is the receiver
    public void OnJumpClicked()
    {
        new ExecuteJump(targetSquare).Perform();
    }

    public void OnCrouchClicked()
    {
        new ExecuteCrouch(targetSquare).Perform();
    }

    public void OnChillClicked()
    {
        new ExecuteChill(targetSquare).Perform();
    }
}
