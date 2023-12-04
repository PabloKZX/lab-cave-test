using TMPro;
using UnityEngine;

public class BestTimeUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _bestTimeText;
    
    void Start()
    {
        UpdateBestTime();
    }

    void UpdateBestTime()
    {
        var model = PlayerModelProvider.Instance.Model;
        
        var bestTime = model.BestTime;
        if(bestTime == TimeManager.kInvalidTime)
        {
            gameObject.SetActive(false);
            return;
        }

        _bestTimeText.SetText($"Best Time:\n{TimeUtils.GetTimeString(bestTime)}");
    }
}
