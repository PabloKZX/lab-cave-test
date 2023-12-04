using UnityEngine;

public class CoinCollector : MonoBehaviour, ICollector
{
    public CollectableType CollectableType => CollectableType.Coin;
    public int CollectablesAmount => _coinsAmount;
    
    int _coinsAmount = 0;
    
    public void OnPickUp()
    {
        var model = PlayerModelProvider.Instance.Model;
        
        ++_coinsAmount;
        ++model.TotalCoinsAmount;
        
        DisplaysManager.Instance.SendUpdateEvent(DisplayType.Coins, CollectablesAmount.ToString());
    }
}
