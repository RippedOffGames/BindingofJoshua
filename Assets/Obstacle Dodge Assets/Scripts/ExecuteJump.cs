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
