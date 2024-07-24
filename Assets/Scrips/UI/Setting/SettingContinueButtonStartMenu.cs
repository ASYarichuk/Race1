using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingContinueButtonStartMenu : MonoBehaviour
{
    [SerializeField] private GameObject _settingWindow;

    public void OnClickButton()
    {
        _settingWindow.SetActive(false);
    }
}
