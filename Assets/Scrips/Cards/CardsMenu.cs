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

    [SerializeField] private GameObject[] _carsLevelFull;
    [SerializeField] private TMP_Text[] _carsTextLevel;
    [SerializeField] private Slider[] _carsSlider;
    [SerializeField] private TMP_Text[] _carsTextSlider;
    [SerializeField] private ActivatorStars[] _carsStars;

    private void Update()
    {
        for (int i = 0; i < _weaponsLevelFull.Length; i++)
        {
            FillCardsWeapon(i);
        }

        for (int i = 0; i < _carsLevelFull.Length; i++)
        {
            FillCardsCar(i);
        }
    }

    private void FillCardsWeapon(int index)
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

    private void FillCardsCar(int index)
    {
        if (ListOfCardsCar.GiveStatusMaxLevel(index))
        {
            _carsLevelFull[index].SetActive(true);
            _carsTextSlider[index].text = $"MAX!";
            _carsSlider[index].value = 1;
            _carsSlider[index].maxValue = 1;
        }
        else
        {
            _carsLevelFull[index].SetActive(false);
            _carsTextSlider[index].text = $"{ListOfCardsCar.GiveCurrentCount(index)}/{ListOfCardsCar.GiveMaxCount(index)}";
            _carsSlider[index].value = ListOfCardsCar.GiveCurrentCount(index);
            _carsSlider[index].maxValue = ListOfCardsCar.GiveMaxCount(index);
        }

        _carsTextLevel[index].text = $"{ListOfCardsCar.GiveLevelCard(index)}";
        _carsStars[index].Activate(ListOfCardsCar.GiveCurrentStars(index));
    }
}
