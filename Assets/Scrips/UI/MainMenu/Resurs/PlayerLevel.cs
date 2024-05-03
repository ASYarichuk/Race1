using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerLevel
{
    private static int _currentExperience = 0;
    private static int _maxLevel = 20;

    private static List<int> _experienceForLevel = new List<int>
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

    public static int Level { get; private set; } = 1;

    public static void AddExperience(int experience)
    {
        if (Level >= _maxLevel)
        {
            return;
        }

        _currentExperience += experience;

        if (_currentExperience > _experienceForLevel[Level - 1])
        {
            _currentExperience -= _experienceForLevel[Level - 1];
            Level += 1;
        }
    }
}
