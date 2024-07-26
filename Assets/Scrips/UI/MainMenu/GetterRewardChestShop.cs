using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetterRewardChestShop : MonoBehaviour
{
    [SerializeField] private int _indexChest;
    [SerializeField] private GameObject _rewardWindow;
    [SerializeField] private GameObject _accordWindow;
    [SerializeField] private CountReward _countReward;
    [SerializeField] private TimerOpenShopChest _timerOpenShopChest;
    [SerializeField] private TimerOpenTextShopChest _timerOpenTextShopChest;
    [SerializeField] private AccordShowVideo _accordShowVideo;

    private readonly int _countRewards = 2;

    private bool _isReady = true;

    public void OnClickButton()
    {
        if (_timerOpenShopChest.GiveTimer() < 0)
            _isReady = true;
        else
            _isReady = false;

        if (_isReady)
        {
            int[] rewardCountStars = new int[_countRewards];
            int[] rewardCountCards = new int[_countRewards];

            for (int i = 0; i < _countRewards; i++)
            {
                int[] reward = _countReward.GiveShopCountStarAndCard(_indexChest);

                rewardCountStars[i] = reward[0];
                rewardCountCards[i] = reward[1];
            }

            GetReward();
            _rewardWindow.GetComponent<RewarderChest>().SetReward(rewardCountStars, rewardCountCards);
        }
        else
        {
            _accordWindow.SetActive(true);
            _accordShowVideo.GetTimerOpenShopChest(_timerOpenShopChest);
        }
    }

    private void GetReward()
    {
        _rewardWindow.SetActive(true);
        _timerOpenShopChest.SetTimer();
        _timerOpenTextShopChest.ChangeImage();
    }
}
