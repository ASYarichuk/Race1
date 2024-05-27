using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListOfCards
{
    private static Card[] _weapons = new Card[21]
    {
        new Card(),
        new Card(),
        new Card(),
        new Card(),
        new Card(),
        new Card(),
        new Card(),
        new Card(),
        new Card(),
        new Card(),
        new Card(),
        new Card(),
        new Card(),
        new Card(),
        new Card(),
        new Card(),
        new Card(),
        new Card(),
        new Card(),
        new Card(),
        new Card()
    };

    public static void AddCard(int numberCard, int count)
    {
        _weapons[numberCard].AddCount(count);
    }
}
