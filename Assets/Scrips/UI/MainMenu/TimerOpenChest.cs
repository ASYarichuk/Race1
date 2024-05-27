using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerOpenChest : MonoBehaviour
{
    [SerializeField] private ListOfChests _listOfChests;

    private float _timeOpen = 0;

    private bool _isOpeningChest = false;

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

    private void Update()
    {
        _timeOpen -= Time.deltaTime;

        CheckTime();
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
                        Debug.Log("Tmer - ChestOne");
                    }

                    break;

                case _chestNumberTwo:
                    if (PlayerPrefs.HasKey(_chestTwo) && PlayerPrefs.GetInt(_chestTwoState) == 0)
                    {
                        _timeOpen = _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestTwo)).GetComponent<Chest>().GiveTimeOpened();
                        _openingChest = _chestNumberTwo;
                        Debug.Log("Tmer - ChestTwo");
                    }

                    break;

                case _chestNumberThree:
                    if (PlayerPrefs.HasKey(_chestThree) && PlayerPrefs.GetInt(_chestThreeState) == 0)
                    {
                        _timeOpen = _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestThree)).GetComponent<Chest>().GiveTimeOpened();
                        _openingChest = _chestNumberThree;
                        Debug.Log("Tmer - ChestThree");
                    }

                    break;

                case _chestNumberFour:
                    if (PlayerPrefs.HasKey(_chestFour) && PlayerPrefs.GetInt(_chestFourState) == 0)
                    {
                        _timeOpen = _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestFour)).GetComponent<Chest>().GiveTimeOpened();
                        _openingChest = _chestNumberFour;
                        Debug.Log("Tmer - ChestFour");
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
