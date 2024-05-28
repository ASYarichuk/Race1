using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListOfCardsWeapon
{
    private static float _valueConverToPercentage = 1;
    private static float _valueCorrectDisplayLevel = 1;
    private static float _rationIncreaseDamage = 0.1f;

    private static CardWeapon[] _cards = new CardWeapon[21]
    {
        new CardWeapon(1,1),
        new CardWeapon(1.5f,1),
        new CardWeapon(2,1),
        new CardWeapon(3.5f,1),
        new CardWeapon(5,1.5f),

        new CardWeapon(0.1f,0.1f),
        new CardWeapon(0.2f,0.1f),
        new CardWeapon(0.35f,0.1f),
        new CardWeapon(0.5f,0.1f),
        new CardWeapon(0.5f,0.05f),

        new CardWeapon(20,15),
        new CardWeapon(30,15),
        new CardWeapon(50,15),
        new CardWeapon(75,15),
        new CardWeapon(100,15),

        new CardWeapon(10,10),
        new CardWeapon(15,10),
        new CardWeapon(25,10),
        new CardWeapon(35,10),
        new CardWeapon(50,15),

        new CardWeapon(100,30)
    };

    public static void AddCard(int numberCard, int count)
    {
        _cards[numberCard].AddCount(count);

        _cards[numberCard].SetDamage(_cards[numberCard].GiveDamage() * 
            (_valueConverToPercentage + _rationIncreaseDamage * 
            (float)(_cards[numberCard].GiveCurrentLevel() - _valueCorrectDisplayLevel)));
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
}
