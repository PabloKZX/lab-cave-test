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
        var bestTime = TimeManager.BestTime;
        if(bestTime == TimeManager.kInvalidTime)
        {
            gameObject.SetActive(false);
            return;
        }

        _bestTimeText.SetText($"Best Time:\n{TimeUtils.GetTimeString(bestTime)}");
    }
}
