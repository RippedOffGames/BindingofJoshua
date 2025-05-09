// tells reciever to switch to mood
// reference is held to receiver (SquareCommander in this case), calls changemood() when perform is executed

public class ExecuteJump : IButtonAction
{
    private SquareCommander receiver;

    public ExecuteJump(SquareCommander receiverRef)
    {
        receiver = receiverRef;
    }

    public void Perform()
    {
        receiver.ChangeMood(new MoodJumping());
    }
}
