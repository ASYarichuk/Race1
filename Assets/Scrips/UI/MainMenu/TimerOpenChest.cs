using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerOpenChest : MonoBehaviour
{
    [SerializeField] private ListOfChests _listOfChests;

    private float _timeOpen = 0;

    private readonly bool _isOpeningChest = false;

    private int _currentChest = 0;
    private readonly int _maxChest = 4;
    private readonly int _openChest = 1;

    private int? _openingChest = null;

    private const int _chestNumberOne = 0;
    private const int _chestNumberTwo = 1;
    private const int _chestNumberThree = 2;
    private const int _chestNumberFour = 3;

    private readonly string _chestOne = "ChestOne";
    private readonly string _chestTwo = "ChestTwo";
    private readonly string _chestThree = "ChestThree";
    private readonly string _chestFour = "ChestFour";
    
    private readonly string _chestOneState = "ChestOneState";
    private readonly string _chestTwoState = "ChestTwoState";
    private readonly string _chestThreeState = "ChestThreeState";
    private readonly string _chestFourState = "ChestFourState";

    private DateTime _dateTimeofPaused;

    private string _timer = "Timer";
    private string _oldTime = "OldTime";

    private void Awake()
    {
        if (PlayerPrefs.HasKey(_timer))
        {
            Debug.Log("Stert");
            _timeOpen = PlayerPrefs.GetFloat(_timer);
            Debug.Log(_timeOpen);
            _timeOpen -= (float)(DateTime.Now - DateTime.Parse(PlayerPrefs.GetString(_oldTime))).TotalSeconds;
            Debug.Log(_timeOpen);

        }
    }

    private void Update()
    {
        _timeOpen -= Time.deltaTime;

        CheckTime();
    }

    private void OnApplicationPause(bool isPaused)
    {
        if (isPaused)
        {
            PlayerPrefs.SetFloat(_timer, _timeOpen);
            PlayerPrefs.SetString(_oldTime, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) ;
            Debug.Log("Paused");
        }
        else
        {
            _timeOpen = PlayerPrefs.GetFloat(_timer);
            _timeOpen -= (float)(DateTime.Now - DateTime.Parse(PlayerPrefs.GetString(_oldTime))).TotalSeconds;
            Debug.Log("OnPaused");
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat(_timer, _timeOpen);
        PlayerPrefs.SetString(_oldTime, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        Debug.Log("Quit");
    }

    private void CheckTime()
    {
        if (_timeOpen <= 0)
        {
            if (_openingChest == _chestNumberOne)
            {
                PlayerPrefs.SetInt(_chestOneState, _openChest);
                _openingChest = null;
            }
            else if (_openingChest == _chestNumberTwo)
            {
                PlayerPrefs.SetInt(_chestTwoState, _openChest);
                _openingChest = null;
            }
            else if (_openingChest == _chestNumberThree)
            {
                PlayerPrefs.SetInt(_chestThreeState, _openChest);
                _openingChest = null;
            }
            else if (_openingChest == _chestNumberFour)
            {
                PlayerPrefs.SetInt(_chestFourState, _openChest);
                _openingChest = null;
            }

            switch (_currentChest)
            {
                case _chestNumberOne:
                    if (PlayerPrefs.HasKey(_chestOne) && PlayerPrefs.GetInt(_chestOneState) == 0)
                    {
                        _timeOpen = _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestOne)).GetComponent<Chest>().GiveTimeOpened();
                        _openingChest = _chestNumberOne;
                    }

                    break;

                case _chestNumberTwo:
                    if (PlayerPrefs.HasKey(_chestTwo) && PlayerPrefs.GetInt(_chestTwoState) == 0)
                    {
                        _timeOpen = _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestTwo)).GetComponent<Chest>().GiveTimeOpened();
                        _openingChest = _chestNumberTwo;
                    }

                    break;

                case _chestNumberThree:
                    if (PlayerPrefs.HasKey(_chestThree) && PlayerPrefs.GetInt(_chestThreeState) == 0)
                    {
                        _timeOpen = _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestThree)).GetComponent<Chest>().GiveTimeOpened();
                        _openingChest = _chestNumberThree;
                    }

                    break;

                case _chestNumberFour:
                    if (PlayerPrefs.HasKey(_chestFour) && PlayerPrefs.GetInt(_chestFourState) == 0)
                    {
                        _timeOpen = _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestFour)).GetComponent<Chest>().GiveTimeOpened();
                        _openingChest = _chestNumberFour;
                    }

                    break;
            }

            _currentChest++;

            if (_currentChest >= _maxChest)
            {
                _currentChest = 0;
            }
        }

        if (_openingChest == null)
        {
            _timeOpen = 0;
        }
    }

    public bool IsOpenerChest()
    {
        return _isOpeningChest;
    }

    public float GiveTimer()
    {
        return _timeOpen;
    }
}
