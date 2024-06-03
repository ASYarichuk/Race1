using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivatorStars : MonoBehaviour
{
    [SerializeField] private GameObject[] _stars;

    public void Activate(int index)
    {
        for (int i = 0; i < index; i++)
        {
            _stars[i].SetActive(true);
        }
    }
}
