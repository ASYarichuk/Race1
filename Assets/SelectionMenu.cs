using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMenu : MonoBehaviour
{
    [SerializeField] private SetterWeapons _setterWeapons;

    private void OnDisable()
    {
        _setterWeapons.CloseSelectionMenu();
    }
}
