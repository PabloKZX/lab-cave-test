using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] CollectableType _type;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] bool _destroyOnCollect;
    [SerializeField] AudioClip _collectSound;

    public event Action OnCollected;
    
    void Collect(ICollector collector)
    {
        if(collector.CollectableType != _type)
        {
            return;
        }
        
        collector.OnPickUp();

        if(_collectSound != null)
        {
            AudioUtility.CreateSFX(_collectSound, transform.position, AudioUtility.AudioGroups.Pickup, 0f);
        }
        
        OnCollected?.Invoke();

        if(_destroyOnCollect)
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if((_layerMask.value & 1 << other.gameObject.layer) <= 0)
        {
            return;
        }

        var collector = other.gameObject.GetComponentInParent<ICollector>();
        if(collector == null)
        {
            return;
        }

        Collect(collector);
    }
}

public enum CollectableType
{
    Coin
}
