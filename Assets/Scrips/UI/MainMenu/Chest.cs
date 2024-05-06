using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private int _timeOpened = 5;
    private bool _isVoid = true;

    public int GiveTimeOpened()
    {
        return _timeOpened;
    }

    public bool GiveState()
    {
        return _isVoid;
    }

    private void Open()
    {

    }
}
