using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnimation : MonoBehaviour
{
    [SerializeField] float _speedX;
    [SerializeField] float _speedY;
    [SerializeField] float _speedZ;
    
    void Update()
    {
        Rotate();
    }
    
    void Rotate()
    {
        var x = _speedX * Time.deltaTime;
        var y = _speedY * Time.deltaTime;
        var z = _speedZ * Time.deltaTime;

        transform.rotation *= Quaternion.Euler(x, y, z);
    }
}
