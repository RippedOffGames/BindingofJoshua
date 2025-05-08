public class ExecuteCrouch : IButtonAction
{
    private SquareCommander receiver;

    public ExecuteCrouch(SquareCommander receiverRef)
    {
        receiver = receiverRef;
    }

    public void Perform()
    {
        receiver.ChangeMood(new MoodCrouching());
    }
}
