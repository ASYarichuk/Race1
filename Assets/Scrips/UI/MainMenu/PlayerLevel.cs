using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public static int _playerlevel { get; private set; } = 1;

    private int _currentExperience = 0;
    private int _maxLevel = 20;

    private List<int> _experienceForLevel = new List<int>
    {
        10,
        25,
        50,
        100,
        150,
        200,
        250,
        400,
        500,
        750,
        1000,
        1500,
        2000,
        2500,
        3000,
        5000,
        7500,
        10000,
        12500,
        25000
    };

    public void AddExperience(int experience)
    {
        if (_playerlevel >= _maxLevel)
        {
            return;
        }

        _currentExperience += experience;

        if (_currentExperience > _experienceForLevel[_playerlevel - 1])
        {
            _currentExperience -= _experienceForLevel[_playerlevel - 1];
            _playerlevel += 1;
        }
    }
}
