using TMPro;
using UnityEngine;

public class TotalCoinsUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    void Start()
    {
        var model = PlayerModelProvider.Instance.Model;
        
        if(model.TotalCoinsAmount == 0)
        {
            gameObject.SetActive(false);
            return;
        }

        _text.text = $"Total Coins:\n{model.TotalCoinsAmount}";
    }
}
