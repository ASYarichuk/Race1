using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreButton : MonoBehaviour
{
    [SerializeField] private GameObject _store;
    [SerializeField] private GameObject _startMenu;

    public void OnClickButton()
    {
        _store.SetActive(true);
        _startMenu.SetActive(false);
    }
}
