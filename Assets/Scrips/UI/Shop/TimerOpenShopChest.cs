using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerOpenShopChest : MonoBehaviour
{
    [SerializeField] private float _timeOpen = 604800;
    private float _currentTime = 0;

    private void Update()
    {
        _currentTime -= Time.deltaTime;
    }

    public float GiveTimer()
    {
        return _currentTime;
    }

    public void SetTimer()
    {
        _currentTime = _timeOpen;
    }
}
