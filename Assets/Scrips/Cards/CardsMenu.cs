using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardsMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _weaponsLevelFull;
    [SerializeField] private TMP_Text[] _weaponsTextLevel;
    [SerializeField] private Slider[] _weaponsSlider;
    [SerializeField] private TMP_Text[] _weaponsTextSlider;

    [SerializeField] private GameObject[] _cars = new GameObject[8];

    private void Update()
    {
        for (int i = 0; i < _weaponsLevelFull.Length; i++)
        {
            FillCards(i);
        }
    }

    private void FillCards(int index)
    {
        if (ListOfCardsWeapon.GiveStatusMaxLevel(index))
        {
            _weaponsLevelFull[index].SetActive(true);
            _weaponsTextSlider[index].text = $"MAX!";
            _weaponsSlider[index].value = 1;
            _weaponsSlider[index].maxValue = 1;
        }
        else
        {
            _weaponsLevelFull[index].SetActive(false);
            _weaponsTextSlider[index].text = $"{ListOfCardsWeapon.GiveCurrentCount(index)}/{ListOfCardsWeapon.GiveMaxCount(index)}";
            _weaponsSlider[index].value = ListOfCardsWeapon.GiveCurrentCount(index);
            _weaponsSlider[index].maxValue = ListOfCardsWeapon.GiveMaxCount(index);
        }

        _weaponsTextLevel[index].text = $"{ListOfCardsWeapon.GiveLevelCard(index)}";
    }
}
