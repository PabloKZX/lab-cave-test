public interface ICollector
{
    public CollectableType CollectableType { get; }
    public int CollectablesAmount { get; }

    public void OnPickUp();
}
