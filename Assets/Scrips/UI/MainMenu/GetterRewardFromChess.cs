using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetterRewardFromChess : MonoBehaviour
{
    [SerializeField] private int _currentPlace;
    [SerializeField] private GameObject _rewardWindow;
    [SerializeField] private CountReward _countReward;
    [SerializeField] private Sprite _void;

    private readonly int _countRewards = 2;
    private readonly int _meaningOpenChest = 1;
    private readonly int _closeChest = 0;

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
            int[] rewardCountStars = new int[_countRewards];
            int[] rewardCountCards = new int[_countRewards];

            for (int i = 0; i < _countRewards; i++)
            {
                int[] reward = _countReward.GiveCountStarAndCard(_currentPlace);

                rewardCountStars[i] = reward[0];
                rewardCountCards[i] = reward[1];
            }

            GetReward();
            _rewardWindow.GetComponent<RewarderChest>().SetReward(rewardCountStars, rewardCountCards);

            PlayerPrefs.DeleteKey(_playerPrefs[_currentPlace]);
            PlayerPrefs.SetInt(_playerPrefsState[_currentPlace], _closeChest);
            gameObject.GetComponent<Image>().sprite = _void;
        }
    }

    private void GetReward()
    {
        _rewardWindow.SetActive(true);
    }
}
