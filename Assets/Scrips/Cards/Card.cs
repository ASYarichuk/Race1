using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card 
{
    private readonly List<int> _cardForLevelUp  = new List<int> 
    { 
        5,
        10,
        25,
        50,
        100,
        150,
        250,
        500,
        1000
    };

    private int _currentLevel = 1;
    private readonly int _maxLevel = 10;
    private int _currentCount = 0;

    private bool _isMaxLevel = false;

    public void AddCount(int count)
    {
        _currentCount += count;

        for (int i = 0; i < _cardForLevelUp.Count; i++)
        {
            if (_currentCount == _maxLevel)
            {
                break;
            }

            if (_currentCount >= _cardForLevelUp[_currentLevel - 1])
            {
                _currentCount -= _cardForLevelUp[_currentLevel - 1];
                AddLevel();
            }
        }
    }

    public int GiveCurrentLevel()
    {
        return _currentLevel;
    }

    public int GiveCurrentCount()
    {
        return _currentCount;
    }

    public int GiveMaxCount()
    {
        return _cardForLevelUp[_currentLevel - 1];
    }

    public bool GiveStatusMaxLevel()
    {
        return _isMaxLevel;
    }

    private void AddLevel()
    {
        if (_currentLevel < _maxLevel)
            _currentLevel += 1;

        if (_currentLevel == _maxLevel)
            _isMaxLevel = true;
    }
}
