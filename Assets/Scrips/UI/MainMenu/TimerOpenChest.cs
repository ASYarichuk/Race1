using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerOpenChest : MonoBehaviour
{
    private float _timeOpen = 0;

    private bool _isOpeningChest = false;

    private int _currentChest = 0;

    private void Update()
    {
        _timeOpen -= Time.deltaTime;

        if (_timeOpen <= 0)
        {
            if (_isOpeningChest)
            {
                PlayerChest.ChangeStateChest(_currentChest);
                _isOpeningChest = false;
            }

            for (int i = 0; i < PlayerChest.MaxCount; i++)
            {
                if (PlayerChest.GiveChest(i) != null && PlayerChest.GiveStateChest(i) == false)
                {
                    _timeOpen = PlayerChest.GiveChest(i).GetComponent<Chest>().GiveTimeOpened();
                    _isOpeningChest = true;
                    _currentChest = i;
                    Debug.Log(_currentChest);
                    return;
                }
                else
                {
                    _timeOpen = 0;
                }
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
