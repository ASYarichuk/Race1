using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerOpenShopChest : MonoBehaviour
{
    [SerializeField] private int _indexPlace;
    [SerializeField] private float _timeOpen = 604800;

    private float _currentTime = 0;

    private readonly string[] _timers = new string[5]
    {
        "TimerOne",
        "TimerTwo",
        "TimerThree",
        "TimerFour",
        "TimerFive",
    };

    private readonly string[] _oldTimes = new string[5]
    {
        "OldTimeOne",
        "OldTimeTwo",
        "OldTimeThree",
        "OldTimeFour",
        "OldTimeFive",
    };

    private void Awake()
    {
        if (PlayerPrefs.HasKey(_timers[_indexPlace]))
        {
            _currentTime = PlayerPrefs.GetFloat(_timers[_indexPlace]);
            _currentTime -= (float)(DateTime.Now - DateTime.Parse(PlayerPrefs.GetString(_oldTimes[_indexPlace]))).TotalSeconds;
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat(_timers[_indexPlace], _currentTime);
        PlayerPrefs.SetString(_oldTimes[_indexPlace], DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_timers[_indexPlace], _currentTime);
        PlayerPrefs.SetString(_oldTimes[_indexPlace], DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
    }

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

    public void RemoveTime(int count)
    {
        _currentTime -= count;
    }
}
