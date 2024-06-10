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

        _text.text = "�������������� ������: \n\n" +
            $"����� - {parametersCar[0]};\n" +
            $"����� - {parametersCar[1]};\n" +
            $"�������� ������ - {parametersCar[2]};\n" +
            $"������������ �������� - {parametersCar[3]};\n\n" +
            "�������������� ������: \n\n" +
            $"���� �������� - {ListOfCardsWeapon.GiveDamage(_indexCurrentGun)}\n" +
            "���������� ����� -5\n" +
            $"���� ������ - {ListOfCardsWeapon.GiveDamage(_indexCurrentRocket)}\n" +
            "���������� ��� -5\n" +
            $"���� ��� - {ListOfCardsWeapon.GiveDamage(_indexCurrentMine)}";
    }
}
