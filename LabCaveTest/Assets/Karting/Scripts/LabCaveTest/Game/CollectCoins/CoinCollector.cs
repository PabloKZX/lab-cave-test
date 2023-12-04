using UnityEngine;

public class CoinCollector : MonoBehaviour, ICollector
{
    public CollectableType CollectableType => CollectableType.Coin;
    
    public void OnPickUp()
    {
        Debug.Log("Picked up coin");
    }
}
