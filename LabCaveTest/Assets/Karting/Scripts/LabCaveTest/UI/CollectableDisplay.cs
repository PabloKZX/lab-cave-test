using TMPro;
using UnityEngine;

public class CollectableDisplay : MonoBehaviour, IUpdateDisplayEventListener
{
    [SerializeField] DisplayType _type;
    [SerializeField] TextMeshProUGUI _amountText;
    
    public DisplayType DisplayType => _type;

    void OnEnable()
    {
        DisplaysManager.Instance.Register(this);
    }

    void OnDisable()
    {
        DisplaysManager.Instance.Unregister(this);
    }

    public void OnUpdateReceived(string amount)
    {
        _amountText.text = amount;
    }
}
