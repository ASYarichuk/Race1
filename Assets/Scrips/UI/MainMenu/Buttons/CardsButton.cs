using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsButton : MonoBehaviour
{
    [SerializeField] private GameObject _cards;
    [SerializeField] private GameObject _startMenu;

    public void OnClickButton()
    {
        _cards.SetActive(true);
        _startMenu.SetActive(false);
    }
}
