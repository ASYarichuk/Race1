using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetterInGameWeaponAndCar : MonoBehaviour
{
    [SerializeField] private GameObject[] _carPrefab;

    private readonly string[] _weaponsAndCar = new string[4]
    {
        "Gun",
        "Rocket",
        "Mine",
        "Car"
    };

    private void OnEnable()
    {
        GameObject player = Instantiate(_carPrefab[PlayerPrefs.GetInt(_weaponsAndCar[3])], transform);

        player.GetComponent<Transform>();
    }
}
