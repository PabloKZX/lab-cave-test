using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RotateAnimation : MonoBehaviour
{
    [SerializeField] float _speedX;
    [SerializeField] float _speedY;
    [SerializeField] float _speedZ;
    [SerializeField] bool _addRandomOffset;

    void Start()
    {
        if(_addRandomOffset)
        {
            AddOffset();
        }
    }

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

    void AddOffset()
    {
        var randomVector = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
        transform.rotation = Quaternion.Euler(randomVector);
    }
}
