using System.Collections.Generic;
using UnityEngine;

public class CollectablesDisplayManager : MonoBehaviour
{
    public static CollectablesDisplayManager Instance
    {
        get
        {
            if(_instance != null)
            {
                return _instance;
            }

            _instance = FindObjectOfType<CollectablesDisplayManager>();
            if(_instance != null)
            {
                return _instance;
            }

            var obj = new GameObject("Collectables Display Manager");
            _instance = obj.AddComponent<CollectablesDisplayManager>();
            return _instance;
        }
    }

    static CollectablesDisplayManager _instance;
    
    List<IUpdateDisplayEventListener> _displays = new();
    

    public void Register(IUpdateDisplayEventListener listener)
    {
        if(!_displays.Contains(listener))
        {
            _displays.Add(listener);
        }
    }

    public void Unregister(IUpdateDisplayEventListener listener)
    {
        if(_displays.Contains(listener))
        {
            _displays.Remove(listener);
        }
    }

    public void SendUpdateEvent(CollectableType type, int amount)
    {
        foreach (var display in _displays)
        {
            if(display.CollectableType != type)
            {
                continue;
            }
            
            display.OnUpdateReceived(amount);
        }
    }
}
