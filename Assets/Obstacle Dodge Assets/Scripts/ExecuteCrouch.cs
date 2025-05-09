// tells reciever to switch to mood
// reference is held to receiver (SquareCommander in this case), calls changemood() when perform is executed

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
