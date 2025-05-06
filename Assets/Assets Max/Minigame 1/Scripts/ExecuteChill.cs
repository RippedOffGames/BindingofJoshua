public class ExecuteChill : IButtonAction
{
    private SquareCommander receiver;

    public ExecuteChill(SquareCommander receiverRef)
    {
        receiver = receiverRef;
    }

    public void Perform()
    {
        receiver.ChangeMood(new ChillMood());
    }
}
