using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMission : MonoBehaviour
{
    [SerializeField] private string _scene;
    [SerializeField] private Resurs _resurs;
    [SerializeField] private int _countEnergyForBattle = 10;

    public void OnClickButton()
    {
        if (_resurs.CheckEnergy(_countEnergyForBattle) == false)
            return;

        _resurs.ReduceEnergy(_countEnergyForBattle);

        SceneManager.LoadScene(_scene);
    }
}
