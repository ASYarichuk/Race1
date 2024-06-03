using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ListCardForReward : MonoBehaviour
{
    [SerializeField] private CardsForReward[] _packOfCards;

    public CardsForReward GivePackOfCards(int index)
    {
       return _packOfCards[index];
    }
}
