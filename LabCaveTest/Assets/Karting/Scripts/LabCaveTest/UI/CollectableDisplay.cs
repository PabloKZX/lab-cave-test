using TMPro;
using UnityEngine;

public class CollectableDisplay : MonoBehaviour, IUpdateDisplayEventListener
{
    [SerializeField] CollectableType _type;
    [SerializeField] TextMeshProUGUI _amountText;
    
    public CollectableType CollectableType => _type;

    void OnEnable()
    {
        CollectablesDisplayManager.Instance.Register(this);
    }

    void OnDisable()
    {
        CollectablesDisplayManager.Instance.Unregister(this);
    }

    public void OnUpdateReceived(int amount)
    {
        _amountText.text = amount.ToString();
    }
}
