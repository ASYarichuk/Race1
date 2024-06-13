using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetterTextParametersCar : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private int _index;

    private void OnEnable()
    {
        float[] parameters = ListOfCardsCar.GiveParameters(_index);

        _text.text = $"Health " +
            $"\n{parameters[0]}" +
            $"\nArmor " +
            $"\n{parameters[1]}" +
            $"\nTorque " +
            $"\n{parameters[2]}" +
            $"\nMax Speed" +
            $"\n{parameters[3]}";
    }
}
