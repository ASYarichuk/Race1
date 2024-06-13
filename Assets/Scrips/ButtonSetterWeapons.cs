using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSetterWeapons : MonoBehaviour
{
    [SerializeField] private GameObject _selectionMenu;

    public void OnClickButton()
    {
        _selectionMenu.SetActive(false);
    }
}
