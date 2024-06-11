using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetterWeaponOnCar : MonoBehaviour
{
    [SerializeField] private GameObject[] _packGuns;
    [SerializeField] private GameObject[] _packRockets;

    public void SetNewGun(int index)
    {
        for (int i = 0; i < _packGuns.Length; i++)
        {
            _packGuns[i].SetActive(false);
        }

        _packGuns[index].SetActive(true);
    } 
    
    public void SetNewRocket(int index)
    {
        for (int i = 0; i < _packRockets.Length; i++)
        {
            _packRockets[i].SetActive(false);
        }

        _packRockets[index].SetActive(true);
    }
}
