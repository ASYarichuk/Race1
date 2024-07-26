using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccordShowVideo : MonoBehaviour
{
    [SerializeField] private GameObject _currentWindow;

    private TimerOpenShopChest _timerOpenShopChest;

    private int _countRemoveTime = 1800;

    public void YesButton()
    {
        _timerOpenShopChest.RemoveTime(_countRemoveTime);
        _currentWindow.SetActive(false);
    }

    public void NoButton()
    {
        _currentWindow.SetActive(false);
    }

    public void GetTimerOpenShopChest(TimerOpenShopChest timerOpenShopChest)
    {
        _timerOpenShopChest = timerOpenShopChest;
    }
}
