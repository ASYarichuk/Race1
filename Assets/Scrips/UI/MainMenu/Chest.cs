using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private int _timeOpened = 20;

    public int GiveTimeOpened()
    {
        return _timeOpened;
    }
}
