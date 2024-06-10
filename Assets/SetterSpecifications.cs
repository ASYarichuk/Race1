using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetterSpecifications : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private readonly string[] _weaponsAndCar = new string[4]
    {
        "Gun",
        "Rocket",
        "Mine",
        "Car"
    };

    private int _indexCurrentCar;
    private int _indexCurrentGun;
    private int _indexCurrentRocket;
    private int _indexCurrentMine;

    private void Update()
    {
        _indexCurrentCar = PlayerPrefs.GetInt(_weaponsAndCar[3]);
        _indexCurrentGun = PlayerPrefs.GetInt(_weaponsAndCar[0]);
        _indexCurrentRocket = PlayerPrefs.GetInt(_weaponsAndCar[1]);
        _indexCurrentMine = PlayerPrefs.GetInt(_weaponsAndCar[2]);

        float[] parametersCar = ListOfCardsCar.GiveParameters(_indexCurrentCar);

        _text.text = "Характеристики машины: \n\n" +
            $"Жизни - {parametersCar[0]};\n" +
            $"Броня - {parametersCar[1]};\n" +
            $"Крутящий момент - {parametersCar[2]};\n" +
            $"Максимальная скорость - {parametersCar[3]};\n\n" +
            "Характеристики оружия: \n\n" +
            $"Урон пулемета - {ListOfCardsWeapon.GiveDamage(_indexCurrentGun)}\n" +
            "Количество ракет -5\n" +
            $"Урон ракеты - {ListOfCardsWeapon.GiveDamage(_indexCurrentRocket)}\n" +
            "Количество мин -5\n" +
            $"Урон мин - {ListOfCardsWeapon.GiveDamage(_indexCurrentMine)}";
    }
}
