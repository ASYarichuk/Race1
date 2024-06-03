using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListOfCardsCar
{
    private readonly static float _valueConverToPercentage = 1;
    private readonly static float _valueCorrectDisplayLevel = 1;
    private readonly static float _rationIncrease = 0.1f;

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
        _cards[numberCard].AddCount(count);

        SetParameters(numberCard);
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

    private static void SetParameters(int numberCard)
    {
        float[] parameters = _cards[numberCard].GiveParameters();

        for (int i = 0; i < parameters.Length; i++)
        {
            parameters[i] = parameters[i] * (_valueConverToPercentage + _rationIncrease * _cards[numberCard].GiveCurrentStars() *
                            (float)(_cards[numberCard].GiveCurrentLevel() - _valueCorrectDisplayLevel));
        }

        _cards[numberCard].SetParameters(parameters);
    }
}
