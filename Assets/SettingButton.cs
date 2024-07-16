using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour
{
    [SerializeField] private GameObject _settingWindow;
    [SerializeField] private GameObject _userInterface;

    public void OnClickButton()
    {
        Time.timeScale = 0f;
        _settingWindow.SetActive(true);
        _userInterface.SetActive(false);
    }
}
