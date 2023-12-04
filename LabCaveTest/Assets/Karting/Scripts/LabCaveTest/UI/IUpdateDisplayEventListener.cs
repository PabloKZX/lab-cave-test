public interface IUpdateDisplayEventListener
{
    public CollectableType CollectableType { get; }

    public void OnUpdateReceived(int amount);
}
