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

    private readonly string _timer = "Timer";
    private readonly string _oldTime = "OldTime";
    private readonly string _chest = "CurrentChest";

    private void Awake()
    {
        if (PlayerPrefs.HasKey(_timer))
        {
            _currentChest = PlayerPrefs.GetInt(_chest);
            _timeOpen = PlayerPrefs.GetFloat(_timer);
            _timeOpen -= (float)(DateTime.Now - DateTime.Parse(PlayerPrefs.GetString(_oldTime))).TotalSeconds;
        }
    }

    private void Update()
    {
        _timeOpen -= Time.deltaTime;

        CheckTime();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(_chest, _currentChest - 1);
        PlayerPrefs.SetFloat(_timer, _timeOpen);
        PlayerPrefs.SetString(_oldTime, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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
                        if (PlayerPrefs.HasKey(_timer))
                        {
                            _timeOpen = PlayerPrefs.GetFloat(_timer);
                            _timeOpen -= (float)(DateTime.Now - DateTime.Parse(PlayerPrefs.GetString(_oldTime))).TotalSeconds;
                            _timeOpen += _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestOne)).GetComponent<Chest>().GiveTimeOpened();
                            _openingChest = _chestNumberOne;
                        }
                        else
                        {
                            _timeOpen = _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestOne)).GetComponent<Chest>().GiveTimeOpened();
                            _openingChest = _chestNumberOne;
                        }
                    }

                    break;

                case _chestNumberTwo:
                    if (PlayerPrefs.HasKey(_chestTwo) && PlayerPrefs.GetInt(_chestTwoState) == 0)
                    {
                        if (PlayerPrefs.HasKey(_timer))
                        {
                            _timeOpen = PlayerPrefs.GetFloat(_timer);
                            _timeOpen -= (float)(DateTime.Now - DateTime.Parse(PlayerPrefs.GetString(_oldTime))).TotalSeconds;
                            _timeOpen += _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestTwo)).GetComponent<Chest>().GiveTimeOpened();
                            _openingChest = _chestNumberTwo;
                        }
                        else
                        {
                            _timeOpen = _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestTwo)).GetComponent<Chest>().GiveTimeOpened();
                            _openingChest = _chestNumberTwo;
                        }
                    }

                    break;

                case _chestNumberThree:
                    if (PlayerPrefs.HasKey(_chestThree) && PlayerPrefs.GetInt(_chestThreeState) == 0)
                    {
                        if (PlayerPrefs.HasKey(_timer))
                        {
                            _timeOpen = PlayerPrefs.GetFloat(_timer);
                            _timeOpen -= (float)(DateTime.Now - DateTime.Parse(PlayerPrefs.GetString(_oldTime))).TotalSeconds;
                            _timeOpen += _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestThree)).GetComponent<Chest>().GiveTimeOpened();
                            _openingChest = _chestNumberThree;
                        }
                        else
                        {
                            _timeOpen = _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestThree)).GetComponent<Chest>().GiveTimeOpened();
                            _openingChest = _chestNumberThree;
                        }
                    }

                    break;

                case _chestNumberFour:
                    if (PlayerPrefs.HasKey(_chestFour) && PlayerPrefs.GetInt(_chestFourState) == 0)
                    {
                        if (PlayerPrefs.HasKey(_timer))
                        {
                            _timeOpen = PlayerPrefs.GetFloat(_timer);
                            _timeOpen -= (float)(DateTime.Now - DateTime.Parse(PlayerPrefs.GetString(_oldTime))).TotalSeconds;
                            _timeOpen += _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestFour)).GetComponent<Chest>().GiveTimeOpened();
                            _openingChest = _chestNumberFour;
                        }
                        else
                        {
                            _timeOpen = _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestFour)).GetComponent<Chest>().GiveTimeOpened();
                            _openingChest = _chestNumberFour;
                        }
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

            if (PlayerPrefs.HasKey(_timer))
            {
                PlayerPrefs.DeleteKey(_timer);
                PlayerPrefs.DeleteKey(_oldTime);
            }
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
    
    public int GiveCurrentChest()
    {
        return _currentChest;
    }
}
