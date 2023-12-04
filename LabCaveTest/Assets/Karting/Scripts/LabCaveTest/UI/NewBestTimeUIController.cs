using System.Collections;
using UnityEngine;

public class NewBestTimeUIController : MonoBehaviour, IUpdateDisplayEventListener
{
    public DisplayType DisplayType => DisplayType.NewRecord;

    [SerializeField] float _messageDuration = 3f;

    void Awake()
    {
        DisplaysManager.Instance.Register(this);
        gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        DisplaysManager.Instance.Unregister(this);
    }

    public void OnUpdateReceived(string text)
    {
        gameObject.SetActive(true);
        StartCoroutine(DeactivateAfterDelay());
    }

    IEnumerator DeactivateAfterDelay()
    {
        yield return new WaitForSeconds(_messageDuration);
        gameObject.SetActive(false);
    }
}
