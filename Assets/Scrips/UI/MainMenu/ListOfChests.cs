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
        return _closeChests[index];
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
