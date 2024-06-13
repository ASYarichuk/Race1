using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetterWeaponOnCar : MonoBehaviour
{
    [SerializeField] private GameObject[] _packGuns;
    [SerializeField] private GameObject[] _packRockets;
    [SerializeField] private GameObject[] _weapons;

    private readonly int _correctRocketIndex = 10;
    private readonly int _countRochet = 5;

    public void SetNewGun(int index)
    {
        for (int i = 0; i < _packGuns.Length; i++)
        {
            _packGuns[i].SetActive(false);
        }

        _packGuns[index].SetActive(true);
        _weapons[0].GetComponent<MachineGun>().SetDamage(ListOfCardsWeapon.GiveDamage(index));
        _weapons[0].GetComponent<MachineGun>().SetCooldown(ListOfCardsWeapon.GiveCooldown(index));
    } 
    
    public void SetNewRocket(int index)
    {
        for (int i = 0; i < _packRockets.Length; i++)
        {
            _packRockets[i].SetActive(false);
        }

        if (index - _correctRocketIndex < _countRochet)
        {
            _weapons[1].SetActive(true);
            _weapons[2].SetActive(false);
            _weapons[1].GetComponent<RocketLauncher>().SetDamage(ListOfCardsWeapon.GiveDamage(index));
            _weapons[1].GetComponent<RocketLauncher>().SetCooldown(ListOfCardsWeapon.GiveCooldown(index));
        }
        else
        {
            _weapons[2].SetActive(true);
            _weapons[1].SetActive(false);
            _weapons[2].GetComponent<RocketLauncher>().SetDamage(ListOfCardsWeapon.GiveDamage(index));
            _weapons[2].GetComponent<RocketLauncher>().SetCooldown(ListOfCardsWeapon.GiveCooldown(index));
        }

        _packRockets[index - _correctRocketIndex].SetActive(true);
        //_mine
    }
}
