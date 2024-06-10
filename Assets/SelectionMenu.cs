using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionMenu : MonoBehaviour
{
    [SerializeField] private SetterWeaponsAndCar[] _setterWeapons;

    private readonly string _currentIndex = "CurrentIndex";

    private readonly int _carIndex = 3;

    public void OnClickButton(GameObject image)
    {
        int currentIndex = PlayerPrefs.GetInt(_currentIndex);

        if (currentIndex == _carIndex)
        {
            _setterWeapons[currentIndex].SetNewCar(image);
        }
        else
        {
            _setterWeapons[currentIndex].SetNewWeapon(image);
            _setterWeapons[currentIndex].CloseSelectionMenu();
        }

        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _setterWeapons[0].CloseSelectionMenu();
    }
}
