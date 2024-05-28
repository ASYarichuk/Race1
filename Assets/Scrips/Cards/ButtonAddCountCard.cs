using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAddCountCard : MonoBehaviour
{
    [SerializeField] private int _card;
    [SerializeField] private int _count;

    public void OnClickButton()
    {
        ListOfCardsWeapon.AddCard(_card, _count);
    }
}
