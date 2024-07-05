using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerOpenTextShopChest : MonoBehaviour
{
    [SerializeField] private TMP_Text _tMP;
    [SerializeField] private TimerOpenShopChest _timerOpenShopText;
    [SerializeField] private GameObject _videoImage;
    [SerializeField] private GameObject _timerImage;

    private readonly string _text = "Бесплатно через: \n";
    private readonly string _textAllChestsOpen = "Бесплатно";

    private int _days = 0;
    private int _hours = 0;
    private int _minutes = 0;
    private int _seconds = 0;
    private readonly int _transferDays = 86400;
    private readonly int _transferHours = 3600;
    private readonly int _transferMinutes = 60;

    private float _timeOpen = 0;

    private void Update()
    {
        _timeOpen = _timerOpenShopText.GiveTimer();

        if (_timeOpen <= 0)
        {
            _tMP.text = _textAllChestsOpen;
            _timerImage.SetActive(false);
            _videoImage.SetActive(true);
            return;
        }

        _days = (int)_timeOpen / _transferDays;
        _hours = (int)(_timeOpen - _days * _transferDays) / _transferHours;
        _minutes = (int)(_timeOpen - _days * _transferDays - _hours * _transferHours) / _transferMinutes;
        _seconds = (int)_timeOpen % _transferMinutes;

        if (_timeOpen > _transferDays)
        {
            _tMP.text = _text + $"{_days:00} дней {_hours:00} часов";
        }
        else if (_timeOpen > _transferHours)
        {
            _tMP.text = _text + $"{_hours:00} : {_minutes:00} : {_seconds:00}";
        }
        else
        {
            _tMP.text = _text + $"{_minutes:00} : {_seconds:00}";
        }
    }

    public void ChangeImage()
    {
        _videoImage.SetActive(false);
        _timerImage.SetActive(true);
    }
}
