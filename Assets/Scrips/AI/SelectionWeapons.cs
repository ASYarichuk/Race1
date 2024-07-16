using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionWeapons : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;

    public int SetWeapon()
    {
        int currentWeapon = Random.Range(0, weapons.Length);
        weapons[currentWeapon].SetActive(true);

        return currentWeapon;
    }
}
