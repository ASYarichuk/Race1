using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingContinueButton : MonoBehaviour
{
    [SerializeField] private GameObject _settingWindow;
    [SerializeField] private GameObject _userInterface;

    public void OnClickButton()
    {
        Time.timeScale = 1f;
        _userInterface.SetActive(true);
        _settingWindow.SetActive(false);
    }
}
