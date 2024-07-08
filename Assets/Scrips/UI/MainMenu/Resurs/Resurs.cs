using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resurs : MonoBehaviour
{
    [SerializeField] private TMP_Text _energy;

    private int _energyCount = 100;
    private readonly int _maxEnergy = 100;

    private void Awake()
    {
        _energy.text = $"{_energyCount} / {_maxEnergy}";
    }

    public void ReduceEnergy(int count)
    {
        _energyCount -= count;
        _energy.text = $"{_energyCount} / {_maxEnergy}";
    }

    public bool CheckEnergy(int count)
    {
        if (_energyCount - count > 0)
        {
            return true;
        }

        return false;
    }
}
