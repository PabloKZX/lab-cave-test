using System.Collections.Generic;
using UnityEngine;

public class DisplaysManager : MonoBehaviour
{
    public static DisplaysManager Instance
    {
        get
        {
            if(_instance != null)
            {
                return _instance;
            }

            _instance = FindObjectOfType<DisplaysManager>();
            if(_instance != null)
            {
                return _instance;
            }

            var obj = new GameObject("Collectables Display Manager");
            _instance = obj.AddComponent<DisplaysManager>();
            return _instance;
        }
    }

    static DisplaysManager _instance;
    
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

    public void SendUpdateEvent(DisplayType type, string text = "")
    {
        foreach (var display in _displays)
        {
            if(display.DisplayType != type)
            {
                continue;
            }
            
            display.OnUpdateReceived(text);
        }
    }
}
