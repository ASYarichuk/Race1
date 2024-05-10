using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    private bool _isVoid = true;

    public bool GiveState()
    {
        return _isVoid;
    }

    public void ChangeState()
    {
        if (_isVoid)
        {
            _isVoid = false;
        }
        else
        {
            _isVoid = true;
        }
    }
}
