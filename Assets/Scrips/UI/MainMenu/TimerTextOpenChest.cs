using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerTextOpenChest : MonoBehaviour
{
    [SerializeField] private TMP_Text _tMP;
    [SerializeField] private TimerOpenChest _timerOpenText;

    private string _text = "Время открытия сундука: ";
    private string _textAllChestsOpen = "Все сундуки открыты";

    private int _hours = 0;
    private int _minutes = 0;
    private int _seconds = 0;
    private int _transferHours = 3600;
    private int _transferMinutes = 60;

    private bool _isOpeningChest = true;

    private float _timeOpen = 0;

    private void Awake()
    {
        _tMP.text = _text + $"{_hours:00} : {_minutes:00} : {_seconds:00}";
    }

    private void Update()
    {
        _timeOpen = _timerOpenText.GiveTimer();

        if (_isOpeningChest == false)
        {
            _timeOpen = 0;
            _tMP.text = _textAllChestsOpen;
            return;
        }

        _hours = (int)_timeOpen / _transferHours;
        _minutes = (int)(_timeOpen - _hours * _transferHours) / _transferMinutes;
        _seconds = (int)_timeOpen % _transferMinutes;

        _tMP.text = _text + $"{_hours:00} : {_minutes:00} : {_seconds:00}";
    }
}
