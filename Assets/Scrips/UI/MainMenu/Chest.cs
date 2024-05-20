using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private int _timeOpened = 20;

    private bool _stateOpen = false;

    public int GiveTimeOpened()
    {
        return _timeOpened;
    }

    public void ChangeState()
    {
        _stateOpen = true;
    }

    public bool IsState()
    {
       return _stateOpen;
    }
}
