using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleButton : MonoBehaviour
{
    [SerializeField] private List<string> _scenes;
    [SerializeField] private Resurs _resurs;
    [SerializeField] private int _countEnergyForBattle = 10;

    public void OnClickButton()
    {
        if (_resurs.CheckEnergy(_countEnergyForBattle) == false)
            return;

        _resurs.ReduceEnergy(_countEnergyForBattle);

        int indexScene = Random.Range(0, _scenes.Count);

        SceneManager.LoadScene(_scenes[indexScene]);
    }
}
