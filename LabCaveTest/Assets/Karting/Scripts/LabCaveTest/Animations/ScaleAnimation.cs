using UnityEngine;
using DG.Tweening;

public class ScaleAnimation : MonoBehaviour
{
    [SerializeField] float _duration = 1f;
    [SerializeField] float _amplitude = 2f;
    [SerializeField] Ease _ease = Ease.InOutQuad;

    Vector3 _initialScale;

    void Start()
    {
        _initialScale = transform.localScale;
        ScaleUp();
    }

    void ScaleUp()
    {
        transform.DOScale(_amplitude, _duration).SetEase(_ease).OnComplete(ScaleDown);
    }

    void ScaleDown()
    {
        transform.DOScale(_initialScale, _duration).SetEase(_ease).OnComplete(ScaleUp);
    }
}
