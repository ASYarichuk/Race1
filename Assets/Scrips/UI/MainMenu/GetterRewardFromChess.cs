using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetterRewardFromChess : MonoBehaviour
{
    [SerializeField] private int _currentPlace;
    [SerializeField] private GameObject _rewardWindow;

    private int _meaningOpenChest = 1;

    private string[] _playerPrefs = new string[4]
    {
        "ChestOne",
        "ChestTwo",
        "ChestThree",
        "ChestFour"
    };

    private string[] _playerPrefsState = new string[4]
    {
        "ChestOneState",
        "ChestTwoState",
        "ChestThreeState",
        "ChestFourState"
    };

    public void OnClickButton()
    {
        if (PlayerPrefs.HasKey(_playerPrefs[_currentPlace]) && PlayerPrefs.GetInt(_playerPrefsState[_currentPlace]) == _meaningOpenChest)
        {
            GetReward();
        }
    }

    private void GetReward()
    {
        _rewardWindow.SetActive(true);
    }
}
