using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetterRewardFromChess : MonoBehaviour
{
    [SerializeField] private int _currentPlace;
    [SerializeField] private GameObject _rewardWindow;

    private readonly int _meaningOpenChest = 1;

    private readonly string[] _playerPrefs = new string[4]
    {
        "ChestOne",
        "ChestTwo",
        "ChestThree",
        "ChestFour"
    };

    private readonly string[] _playerPrefsState = new string[4]
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
            int[] rewardCountStars = new int[2] {1, 1};
            int[] rewardCountCards = new int[2] {5000, 5000};

            GetReward();
            _rewardWindow.GetComponent<RewarderChest>().SetReward(rewardCountStars, rewardCountCards);
        }
    }

    private void GetReward()
    {
        _rewardWindow.SetActive(true);
    }
}
