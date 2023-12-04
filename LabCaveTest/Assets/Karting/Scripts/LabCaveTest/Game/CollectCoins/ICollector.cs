public interface ICollector
{
    public CollectableType CollectableType { get; }

    public void OnPickUp();
}
