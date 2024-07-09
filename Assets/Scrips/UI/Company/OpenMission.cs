using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMission : MonoBehaviour
{
    [SerializeField] private string _scene;
    [SerializeField] private Resurs _resurs;
    [SerializeField] private int _countEnergyForBattle = 10;
    [SerializeField] private int _indexMission;

    private readonly string _isMission = "IsMission"; 
    private readonly string _currentMission = "CurrentMission"; 

    public void OnClickButton()
    {
        if (_resurs.CheckEnergy(_countEnergyForBattle) == false)
            return;

        _resurs.ReduceEnergy(_countEnergyForBattle);

        PlayerPrefs.SetInt(_isMission, 1);
        PlayerPrefs.SetInt(_currentMission, _indexMission);

        SceneManager.LoadScene(_scene);
    }
}
