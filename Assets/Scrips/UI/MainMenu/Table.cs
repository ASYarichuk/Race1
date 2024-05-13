using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Table
{
    private static bool[] _stateTable = new bool[4]
    {
        true,
        true,
        true,
        true
    };

    public static bool GiveState(int index)
    {
        return _stateTable[index];
    }

    public static void ChangeState(int index)
    {
        if (_stateTable[index])
        {
            _stateTable[index] = false;
        }
        else
        {
            _stateTable[index] = true;
        }
    }
}
