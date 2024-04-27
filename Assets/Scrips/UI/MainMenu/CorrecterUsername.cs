using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CorrecterUsername : MonoBehaviour
{
    [SerializeField] private TMP_Text _username;
    [SerializeField] private TMP_Text _currentUsername;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private GameObject _correcterName;

    private string _currentName;

    private void Update()
    {
        _currentName = _username.text;
    }

    public void OnClickButtonNO()
    {
        _correcterName.SetActive(false);
    }

    public void OnClickButtonYES()
    {
        _currentUsername.text = _currentName;
        _correcterName.SetActive(false);
    }

    public void Open()
    {
        _correcterName.SetActive(true);
        _inputField.text = "";
    }
}
