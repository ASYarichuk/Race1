using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerOpenChest : MonoBehaviour
{
    [SerializeField] private string _text = "Время до открытия следующего сундука: ";

    [SerializeField] private TMP_Text _tMP;

    [SerializeField] private float _timeOpen = 30;

    private int hours;
    private int minutes;
    private int seconds;

    private int transferHours = 3600;
    private int transferMinutes = 60;

    private void Update()
    {
        _timeOpen -= Time.deltaTime;
        hours = (int)_timeOpen / transferHours;
        minutes = (int)(_timeOpen - hours * transferHours) / transferMinutes;
        seconds = (int)_timeOpen % transferMinutes;

        _tMP.text = _text + $"{hours:00} : {minutes:00} : {seconds:00}";
    }
}
