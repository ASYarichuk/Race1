using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resurs : MonoBehaviour
{
    [SerializeField] private TMP_Text _energy;
    [SerializeField] private TMP_Text _gold;
    [SerializeField] private TMP_Text _cristals;

    private int _energyCount = 30;
   // private int _goldCount = 100;
    //private int _cristalsCount = 0;

    public void ReduceEnergy(int count)
    {
        _energyCount -= count;
    }

    public bool CheckEnergy(int count)
    {
        if (_energyCount - count > 0)
        {
            return true;
        }

        return false;
    }

    private void AddEnergy()
    {

    }


}
