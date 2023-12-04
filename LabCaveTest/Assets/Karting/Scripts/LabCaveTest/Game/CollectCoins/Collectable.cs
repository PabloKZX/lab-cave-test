using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] CollectableType _type;
    [SerializeField] LayerMask _layerMask;
    
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
        
        if(collector.CollectableType == _type)
        {
            collector.OnPickUp();
        }
    }
}

public enum CollectableType
{
    Coin
}
