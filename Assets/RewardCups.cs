using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RewardCups : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void Show(int cups)
    {
        _text.text = $"+{cups}";
    }
}
