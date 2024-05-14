using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerOpenChest : MonoBehaviour
{
    private float _timeOpen = 0;

    private bool _isOpeningChest = false;

    private void Update()
    {
        _timeOpen -= Time.deltaTime;

        if (_timeOpen <= 0)
        {
            if (_isOpeningChest)
            {
                PlayerChest.OpenChest();
                _isOpeningChest = false;
            }

            if (PlayerChest.GiveChest(0) != null)
            {
                _timeOpen = PlayerChest.GiveChest(0).GetComponent<Chest>().GiveTimeOpened();
                _isOpeningChest = true;
            }
            else
            {
                _timeOpen = 0;
            }
        }
    }

    public bool IsOpenerChest()
    {
        return _isOpeningChest;
    }

    public float GiveTimer()
    {
        return _timeOpen;
    }
}
