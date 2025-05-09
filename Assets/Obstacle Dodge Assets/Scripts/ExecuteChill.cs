public class ExecuteChill : IButtonAction
{
    private SquareCommander receiver;
    // tells reciever to switch to mood
    // reference is held to receiver (SquareCommander in this case), calls changemood() when perform is executed
    public ExecuteChill(SquareCommander receiverRef)
    {
        receiver = receiverRef;
    }

    public void Perform()
    {
        receiver.ChangeMood(new ChillMood());
    }
}
