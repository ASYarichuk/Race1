using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStarter : MonoBehaviour
{
    [SerializeField] private GameObject[] _carPrefab;
    [SerializeField] private GameObject[] _startPositions;

    [SerializeField] private int _countAIPlayer = 4;

    [SerializeField] private float _minValue = 0.8f;
    [SerializeField] private float _maxValue = 1.2f;

    private readonly int _amountWeapon = 4;
    private readonly int _indexGun = 5;
    private readonly int _correlationCoefficientGunMinigun = 10;
    private readonly int _indexGunAIWeapon = 1;

    private readonly string[] _weaponsAndCar = new string[4]
    {
        "Gun",
        "Rocket",
        "Mine",
        "Car"
    };

    private void OnEnable()
    {
        float gunDamage = ListOfCardsWeapon.GiveDamage(PlayerPrefs.GetInt(_weaponsAndCar[0]));
        float gunCooldown = ListOfCardsWeapon.GiveCooldown(PlayerPrefs.GetInt(_weaponsAndCar[0]));

        float rocketDamage = ListOfCardsWeapon.GiveDamage(PlayerPrefs.GetInt(_weaponsAndCar[1]));
        float rocketCooldown = ListOfCardsWeapon.GiveCooldown(PlayerPrefs.GetInt(_weaponsAndCar[1]));

        float[] parametersPlayer = ListOfCardsCar.GiveParameters(PlayerPrefs.GetInt(_weaponsAndCar[3]));

        for (int i = 0; i < _countAIPlayer; i++)
        {
            GameObject enemy = Instantiate(_carPrefab[Random.Range(0, _carPrefab.Length)], _startPositions[i].transform);

            enemy.GetComponentInChildren<AIRocketLauncher>().SetDamage(Random.Range(rocketDamage * _minValue, rocketDamage * _maxValue));
            enemy.GetComponentInChildren<AIRocketLauncher>().SetCooldown(Random.Range(rocketCooldown * _minValue, rocketCooldown * _maxValue));

            SelectionWeapons[] weapons = enemy.GetComponentsInChildren<SelectionWeapons>();
            int[] currentIndexWeapon = new int[_amountWeapon];

            for (int j = 0; j < weapons.Length; j++)
            {
                currentIndexWeapon[j] = weapons[j].SetWeapon();
            }

            if (PlayerPrefs.GetInt(_weaponsAndCar[0]) < _indexGun)
            {
                if (currentIndexWeapon[_indexGunAIWeapon] > _indexGun)
                {
                    enemy.GetComponentInChildren<AIMachineGun>().SetDamage
                        (Random.Range(gunDamage * _minValue / _correlationCoefficientGunMinigun, gunDamage * _maxValue / _correlationCoefficientGunMinigun));
                    enemy.GetComponentInChildren<AIMachineGun>().SetCooldown
                        (Random.Range(gunCooldown * _minValue / _correlationCoefficientGunMinigun, gunCooldown * _maxValue / _correlationCoefficientGunMinigun));
                }
                else
                {
                    enemy.GetComponentInChildren<AIMachineGun>().SetDamage
                    (Random.Range(gunDamage * _minValue, gunDamage * _maxValue));
                    enemy.GetComponentInChildren<AIMachineGun>().SetCooldown
                        (Random.Range(gunCooldown * _minValue, gunCooldown * _maxValue));
                }
            }
            else
            {
                if (currentIndexWeapon[_indexGunAIWeapon] < _indexGun)
                {
                    enemy.GetComponentInChildren<AIMachineGun>().SetDamage
                        (Random.Range(gunDamage * _minValue * _correlationCoefficientGunMinigun, gunDamage * _maxValue * _correlationCoefficientGunMinigun));
                    enemy.GetComponentInChildren<AIMachineGun>().SetCooldown
                        (Random.Range(gunCooldown * _minValue * _correlationCoefficientGunMinigun, gunCooldown * _maxValue * _correlationCoefficientGunMinigun));
                }
                else
                {
                    enemy.GetComponentInChildren<AIMachineGun>().SetDamage
                    (Random.Range(gunDamage * _minValue, gunDamage * _maxValue));
                    enemy.GetComponentInChildren<AIMachineGun>().SetCooldown
                        (Random.Range(gunCooldown * _minValue, gunCooldown * _maxValue));
                }
            }

            enemy.GetComponent<Car>().SetHealth(Random.Range(parametersPlayer[0] * _minValue, parametersPlayer[0] * _maxValue));
            enemy.GetComponent<Car>().SetArmor(Random.Range(parametersPlayer[1] * _minValue, parametersPlayer[1] * _maxValue));

            enemy.GetComponent<AIMover>().SetTorque(Random.Range(parametersPlayer[2] * _minValue, parametersPlayer[2] * _maxValue));
            enemy.GetComponent<AIMover>().SetMaxSpeed(Random.Range(parametersPlayer[3] * _minValue, parametersPlayer[3] * _maxValue));
        }
    }
}
