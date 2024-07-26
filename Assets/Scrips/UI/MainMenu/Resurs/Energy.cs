using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Energy : MonoBehaviour
{
    [SerializeField] private TMP_Text _energy;

    private int _energyCount = 100;
    private readonly int _maxEnergy = 100;

    private readonly float _timeAddEnergy = 120;
    private float _currentTime = 0;

    private readonly string _timerEnergy = "TimerEnergy";
    private readonly string _oldTimeEnergy = "OldTimeEnergy";

    private void Awake()
    {
        if (PlayerPrefs.HasKey(_timerEnergy))
        {
            _currentTime = PlayerPrefs.GetFloat(_timerEnergy);
            _currentTime -= (float)(DateTime.Now - DateTime.Parse(PlayerPrefs.GetString(_oldTimeEnergy))).TotalSeconds;
        }

        _energy.text = $"{_energyCount} / {_maxEnergy}";
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat(_timerEnergy, _currentTime);
        PlayerPrefs.SetString(_oldTimeEnergy, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
    }


    private void Update()
    {
        if (_energyCount != _maxEnergy)
        {
            _currentTime += Time.deltaTime;
        }

        if (_currentTime > _timeAddEnergy && _energyCount < _maxEnergy)
        {
            _energyCount++;
            _currentTime -= _timeAddEnergy;
        }

        if (_energyCount == _maxEnergy)
        {
            _currentTime = 0;
        }
    }

    public void ReduceEnergy(int count)
    {
        _energyCount -= count;
        _energy.text = $"{_energyCount} / {_maxEnergy}";
    }

    public bool CheckEnergy(int count)
    {
        if (_energyCount - count > 0)
        {
            return true;
        }

        return false;
    }

    public float GiveCurrentTime()
    {
        return _currentTime;
    }
}
