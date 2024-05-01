using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private List<int> _cardForLevelUp  = new List<int> 
    { 
        5,
        10,
        25,
        50,
        100,
        150,
        250,
        500,
        750,
        1000
    };

    private int _currentLevel = 0;
    private int _maxLevel = 10;

    private int _currentCount = 0;

    public void AddCount(int count)
    {
        _currentCount += count;
    }

    private void AddLevel()
    {
        if (_currentLevel + 1 <= _maxLevel)
            _currentLevel += 1;
    }
}
