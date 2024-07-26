using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserName : MonoBehaviour
{
    [SerializeField] private TMP_Text _userName;

    private string _currentUserName = "UserName";

    private void Awake()
    {
        _userName.text = PlayerPrefs.GetString(_currentUserName);
    }
}
