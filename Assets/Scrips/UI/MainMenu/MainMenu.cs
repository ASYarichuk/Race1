using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private ListOfChests _listOfChests;
    [SerializeField] private ChestsMenu _chestsMenu;

    private int _numberChest;

    private void OnEnable()
    {
        if (PlayerChest.GivenChest)
        {
            //int _numberChest = PlayerChest.GiveChest();
        }
    }
}
