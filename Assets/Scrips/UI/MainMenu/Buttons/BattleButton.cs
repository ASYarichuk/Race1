using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleButton : MonoBehaviour
{
    [SerializeField] private List<string> _scenes;
    [SerializeField] private Energy _resurs;
    [SerializeField] private int _countEnergyForBattle = 10;

    private readonly string _isMission = "IsMission";
    private readonly int _meaningNoMission = 0;

    public void OnClickButton()
    {
        if (_resurs.CheckEnergy(_countEnergyForBattle) == false)
            return;

        _resurs.ReduceEnergy(_countEnergyForBattle);

        PlayerPrefs.SetInt(_isMission, _meaningNoMission);

        int indexScene = Random.Range(0, _scenes.Count);

        SceneManager.LoadScene(_scenes[indexScene]);
    }
}
