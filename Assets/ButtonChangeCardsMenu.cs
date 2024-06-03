using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChangeCardsMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _cards;

    private int currentCardsMenu = 0;

    public void OnClickButton()
    {
        if (currentCardsMenu == 0)
        {
            _cards[0].SetActive(false);
            _cards[1].SetActive(true);
            currentCardsMenu = 1;
        }
        else
        {
            _cards[0].SetActive(true);
            _cards[1].SetActive(false);
            currentCardsMenu = 0;
        }
    }
}
