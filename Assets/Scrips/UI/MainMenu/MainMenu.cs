using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private ListOfChests _listOfChests;
    [SerializeField] private ChestsMenu _chestsMenu;

    private void Awake()
    {
        Debug.Log("Для чего этот скрипт?");
    }


}
