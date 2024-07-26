using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMission : MonoBehaviour
{
    [SerializeField] private string _scene;
    [SerializeField] private Energy _resurs;
    [SerializeField] private int _countEnergyForBattle = 10;
    [SerializeField] private int _indexMission;
    [SerializeField] private TimerOpenChest _timerOpenChest;

    private readonly string _isMission = "IsMission"; 
    private readonly string _currentMission = "CurrentMission";

    private readonly string _timer = "Timer";
    private readonly string _oldTime = "OldTime";
    private readonly string _chest = "CurrentChest";
    private readonly string _timerEnergy = "TimerEnergy";
    private readonly string _oldTimeEnergy = "OldTimeEnergy";

    private readonly int _correctIndexChest = 1;

    public void OnClickButton()
    {
        if (_resurs.CheckEnergy(_countEnergyForBattle) == false)
            return;

        _resurs.ReduceEnergy(_countEnergyForBattle);

        PlayerPrefs.SetInt(_isMission, 1);
        PlayerPrefs.SetInt(_currentMission, _indexMission);

        Save();

        SceneManager.LoadScene(_scene);
    }

    private void Save()
    {
        PlayerPrefs.SetFloat(_timer, _timerOpenChest.GiveTimer());
        PlayerPrefs.SetInt(_chest, _timerOpenChest.GiveCurrentChest() - _correctIndexChest);
        PlayerPrefs.SetString(_oldTime, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        PlayerPrefs.SetFloat(_timerEnergy, _resurs.GiveCurrentTime());
        PlayerPrefs.SetString(_oldTimeEnergy, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
    }
}
