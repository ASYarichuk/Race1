using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetterCardIndex : MonoBehaviour
{
    private int _index = 0;

    public void SetIndex(int index)
    {
        _index = index;
    }

    public int GiveIndex()
    {
        return _index;
    }
}
