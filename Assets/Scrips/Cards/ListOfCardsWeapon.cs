using System;

public static class ListOfCardsWeapon
{
    private readonly static float _valueConverToPercentage = 1;
    private readonly static float _valueCorrectDisplayLevel = 1;
    private readonly static float _rationIncreaseDamage = 0.1f;

    private readonly static CardWeapon[] _cards = new CardWeapon[21]
    {
        new CardWeapon(1,1,1,false, true),
        new CardWeapon(1.5f,1,2,false, false),
        new CardWeapon(2,1,3,false, false),
        new CardWeapon(3.5f,1,4,false, false),
        new CardWeapon(5,1.5f,5,false, false),

        new CardWeapon(0.1f,0.1f,1,false, true),
        new CardWeapon(0.2f,0.1f,2,false, false),
        new CardWeapon(0.35f,0.1f,3,false, false),
        new CardWeapon(0.5f,0.1f,4,false, false),
        new CardWeapon(0.5f,0.05f,5,false, false),

        new CardWeapon(20,15,1,false, true),
        new CardWeapon(30,15,2,false, false),
        new CardWeapon(50,15,3,false, false),
        new CardWeapon(75,15,4,false, false),
        new CardWeapon(100,15,5,false, false),

        new CardWeapon(10,10,1,false, true),
        new CardWeapon(15,10,2,false, false),
        new CardWeapon(25,10,3,false, false),
        new CardWeapon(35,10,4,false, false),
        new CardWeapon(50,15,5,false, false),

        new CardWeapon(100,30,5,false, true)
    };

    public static void AddCard(int numberCard, int count)
    {
        _cards[numberCard].AddCount(count);

        _cards[numberCard].SetDamage(_cards[numberCard].GiveDamage() * _cards[numberCard].GiveCurrentStars() *
            (_valueConverToPercentage + _rationIncreaseDamage *
            (float)(_cards[numberCard].GiveCurrentLevel() - _valueCorrectDisplayLevel)));

        if (_cards[numberCard].GiveStateOpen() == false)
        {
            _cards[numberCard].ChangeStateOpen();
        }
    }

    public static float GiveDamage(int numberCard)
    {
        return _cards[numberCard].GiveDamage();
    }
    
    public static float GiveCooldown(int numberCard)
    {
        return _cards[numberCard].GiveCooldown();
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

    public static bool GiveStatusStateOpen(int numberCard)
    {
        return _cards[numberCard].GiveStateOpen();
    }
}
