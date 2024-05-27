using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _weapons = new GameObject[21];
    [SerializeField] private GameObject[] _cars = new GameObject[8];



    private void OnEnable()
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            FillCards(i);
        }
    }

    private void FillCards(int index)
    {
       
    }
}
