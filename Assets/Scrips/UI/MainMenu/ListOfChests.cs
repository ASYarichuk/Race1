using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListOfChests : MonoBehaviour
{
    [SerializeField] private GameObject[] _closeChests;
    [SerializeField] private Sprite[] _openChests;
    [SerializeField] private Sprite _voidChests;

    [SerializeField] private List<GameObject> _tempListForOneChest;

    public GameObject GiveCloseChest(int index)
    {
        //_tempListForOneChest.Clear();

        /*for (int i = 0; i < _closeChests.Length; i++)
        {
            _tempListForOneChest.Add(_closeChests[i]);
        }*/

        var newChest = Instantiate(_closeChests[index]);

        return newChest;
    }

    public Sprite GiveOpenChest(int index)
    {
        return _openChests[index];
    }

    public Sprite GiveVoidChest()
    {
        return _voidChests;
    }
}
