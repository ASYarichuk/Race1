using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Energy : MonoBehaviour
{
    [SerializeField] private TMP_Text _energy;

    private int _energyCount = 100;
    private readonly int _maxEnergy = 100;

    private readonly float _timeAddEnergy = 120;
    private float _currentTimeAddEnergy = 0;

    private void Awake()
    {
        _energy.text = $"{_energyCount} / {_maxEnergy}";
    }

    private void Update()
    {
        if (_energyCount != _maxEnergy)
        {
            _currentTimeAddEnergy += Time.deltaTime;
        }
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
