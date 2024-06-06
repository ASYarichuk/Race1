using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListOfCardsCar
{
    private readonly static float _valueConverToPercentage = 1;
    private readonly static float _valueCorrectDisplayLevel = 1;
    private static float _rationIncreaseSpeed = 0.01f;
    private static float _rationIncreaseArmor = 0.05f;
    private readonly static float _startRationIncreaseSpeed = 0.01f;
    private readonly static float _startRationIncreaseArmor = 0.05f;
    private readonly static float _rationIncreaseSpeedForFiveStar = 0.00085f;
    private readonly static float _rationIncreaseSpeedForFourStar = 0.001f;
    private readonly static float _rationIncreaseSpeedForThreeStar = 0.003f;
    private readonly static float _rationIncreaseArmorForFiveStar = 0.005f;
    private readonly static float _rationIncreaseArmorForFourStar = 0.01f;
    private readonly static float _rationIncreaseArmorForThreeStar = 0.02f;

    private readonly static CardCar[] _cards = new CardCar[8]
    {
        new CardCar(200,10,450,90, true),
        new CardCar(250,15,420,85, true),
        new CardCar(300,8,450,90, true),
        new CardCar(400,20,380,80, true),
        new CardCar(150,10,500,100, true),
        new CardCar(200,12,450,90, true),
        new CardCar(250,15,440,90, true),
        new CardCar(200,7,470,95, true)
    };

    public static void AddCard(int numberCard, int count)
    {
        int countLevelUp = _cards[numberCard].AddCount(count);

        SetParameters(numberCard, countLevelUp);
    }

    public static int GiveLevelCard(int numberCard)
    {
        return _cards[numberCard].GiveCurrentLevel();
    }

    public static int GiveCurrentCount(int numberCard)
    {
        return _cards[numberCard].GiveCurrentCount();
    }

    public static int GiveMaxCount(int numberCard)
    {
        return _cards[numberCard].GiveMaxCount();
    }

    public static bool GiveStatusMaxLevel(int numberCard)
    {
        return _cards[numberCard].GiveStatusMaxLevel();
    }

    public static int GiveCurrentStars(int numberCard)
    {
        return _cards[numberCard].GiveCurrentStars();
    }

    public static float[] GiveParameters(int numberCard)
    {
        return _cards[numberCard].GiveParameters();
    }

    private static void SetParameters(int numberCard, int countLevelUp)
    {     
        int levelPerStar = 5;

        for (int i = countLevelUp; i > 0; i--)
        {
            float currentStar = _cards[numberCard].GiveCurrentStars();
            float currentLevel = _cards[numberCard].GiveCurrentLevel();

            currentLevel -= countLevelUp;
            countLevelUp--;

            if (currentLevel < 1)
            {
                currentLevel += _cards[numberCard].GiveCurrentStars() * levelPerStar - levelPerStar; 
                currentStar--;
            }

            float[] parameters = _cards[numberCard].GiveParameters();

            if (currentStar == 5)
            {
                _rationIncreaseSpeed = _rationIncreaseSpeedForFiveStar;
                _rationIncreaseArmor = _rationIncreaseArmorForFiveStar;
            }
            else if (currentStar == 4)
            {
                _rationIncreaseSpeed = _rationIncreaseSpeedForFourStar;
                _rationIncreaseArmor = _rationIncreaseArmorForFourStar;
            }
            else if (currentStar == 3)
            {
                _rationIncreaseSpeed = _rationIncreaseSpeedForThreeStar;
                _rationIncreaseArmor = _rationIncreaseArmorForThreeStar;
            }
            else
            {
                _rationIncreaseSpeed = _startRationIncreaseSpeed;
                _rationIncreaseArmor = _startRationIncreaseArmor;
            }

            parameters[0] = parameters[0] * (_valueConverToPercentage + _rationIncreaseSpeed * currentStar *
                           (currentLevel * _valueCorrectDisplayLevel));

            parameters[1] = parameters[1] + _rationIncreaseArmor * currentStar *
                            (currentLevel * _valueCorrectDisplayLevel);

            _cards[numberCard].SetParameters(parameters);
        }
    }
}
