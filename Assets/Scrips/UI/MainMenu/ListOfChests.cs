using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListOfChests : MonoBehaviour
{
    [SerializeField] private Sprite[] _closeChests;
    [SerializeField] private Sprite[] _openChests;

    public Sprite GiveCloseChest(int index)
    {
        return _closeChests[index];
    }

    public Sprite GiveOpenChest(int index)
    {
        return _openChests[index];
    }
}
