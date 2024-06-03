using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivatorStars : MonoBehaviour
{
    [SerializeField] private GameObject[] _stars;

    private int _maxStars = 5;

    public void Activate(int index)
    {
        for (int i = 0; i < index; i++)
        {
            _stars[i].SetActive(true);
        }
    }

    public void Deactivate()
    {
        for (int i = 0; i < _maxStars; i++)
        {
            _stars[i].SetActive(false);
        }
    }
}
