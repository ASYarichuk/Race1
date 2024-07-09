using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButton : MonoBehaviour
{
    [SerializeField] private Buttons[] _buttons = new Buttons[9];

    public Buttons GiveButton(int index)
    {
        return _buttons[index];
    }
}
