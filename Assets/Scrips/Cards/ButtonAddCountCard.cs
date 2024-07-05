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
    [SerializeField] private int _count;

    public void OnClickButton()
    {
        ListOfCardsCar.AddCard(_card1, _count);
        ListOfCardsCar.AddCard(_card2, _count);
        ListOfCardsCar.AddCard(_card3, _count);
        ListOfCardsCar.AddCard(_card4, _count);
        ListOfCardsCar.AddCard(_card5, _count);
        ListOfCardsCar.AddCard(_card6, _count);
        ListOfCardsCar.AddCard(_card7, _count);
        ListOfCardsCar.AddCard(_card8, _count);
    }
}
