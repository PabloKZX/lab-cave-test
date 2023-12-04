public interface IUpdateDisplayEventListener
{
    public DisplayType DisplayType { get; }

    public void OnUpdateReceived(string text);
}
