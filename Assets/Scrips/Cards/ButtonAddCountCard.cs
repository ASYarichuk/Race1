using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAddCountCard : MonoBehaviour
{
    [SerializeField] private int _card1;
    [SerializeField] private int _card2;
    [SerializeField] private int _card3;
    [SerializeField] private int _card4;
    [SerializeField] private int _card5;
    [SerializeField] private int _card6;
    [SerializeField] private int _card7;
    [SerializeField] private int _card8;
    [SerializeField] private int _card9;
    [SerializeField] private int _card10;
    [SerializeField] private int _count;

    public void OnClickButton()
    {
        ListOfCardsWeapon.AddCard(_card1, _count);
        ListOfCardsWeapon.AddCard(_card2, _count);
        ListOfCardsWeapon.AddCard(_card3, _count);
        ListOfCardsWeapon.AddCard(_card4, _count);
        ListOfCardsWeapon.AddCard(_card5, _count);
        ListOfCardsWeapon.AddCard(_card6, _count);
        ListOfCardsWeapon.AddCard(_card7, _count);
        ListOfCardsWeapon.AddCard(_card8, _count);
        ListOfCardsWeapon.AddCard(_card9, _count);
        ListOfCardsWeapon.AddCard(_card10, _count);
    }
}
