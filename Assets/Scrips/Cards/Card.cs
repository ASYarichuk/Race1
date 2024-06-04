using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    private readonly List<int> _cardForLevelUp = new()
    {
        5,
        10,
        25,
        50,
        100,
        120,
        150,
        200,
        300,
        450,
        500,
        600,
        650,
        700,
        750,
        800,
        900,
        1000,
        1100,
        1300,
        1500,
        1750,
        2000,
        3000,
        4000,
        5000
    };

    private int _currentLevel = 1;
    private int _maxLevel = 5;
    private int _currentCount = 0;
    private readonly int _levelPerStar = 5;
    private int _currentStar = 1;
    private readonly int _maxStar = 5;

    private bool _isMaxLevel = false;
    private bool _isIncreaseMaxStar = false;

    public int AddCount(int count)
    {
        int countLevelUp = 0;

        _currentCount += count;

        for (int i = 0; i < _cardForLevelUp.Count; i++)
        {
            if (_currentLevel == _maxLevel)
            {
                if (_isIncreaseMaxStar)
                {
                    _currentStar++;
                    SetMaxLevel(_currentStar);

                    _currentLevel = 1;

                    i = 0;

                    if (_currentStar >= _maxStar)
                    {
                        _isIncreaseMaxStar = false;
                    }

                    continue;
                }
            }

            if (_currentCount >= _cardForLevelUp[_currentLevel - 1])
            {
                _currentCount -= _cardForLevelUp[_currentLevel - 1];
                AddLevel();
                countLevelUp++;
            }
        }

        return countLevelUp;
    }

    public int GiveCurrentLevel()
    {
        return _currentLevel;
    }

    public int GiveCurrentCount()
    {
        return _currentCount;
    }

    public int GiveCurrentStars()
    {
        return _currentStar;
    }

    public int GiveMaxCount()
    {
        return _cardForLevelUp[_currentLevel - 1];
    }

    public bool GiveStatusMaxLevel()
    {
        return _isMaxLevel;
    }

    public void SetMaxLevel(int countStar)
    {
        _maxLevel = countStar * _levelPerStar;
    }

    public void SetIncreaseMaxLevel(bool isIncreaseMaxLevel)
    {
        _isIncreaseMaxStar = isIncreaseMaxLevel;
    }

    private void AddLevel()
    {
        if (_currentLevel < _maxLevel)
            _currentLevel += 1;

        if (_currentLevel == _maxLevel && _isIncreaseMaxStar == false)
            _isMaxLevel = true;
    }
}
