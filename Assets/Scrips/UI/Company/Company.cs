using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Company : MonoBehaviour
{
    [SerializeField] private ActivatorStars[] _paths;
    [SerializeField] private GameObject[] _yellowIcons;
    [SerializeField] private GameObject[] _violetIcons;
    [SerializeField] private GameObject[] _redIcons;
    [SerializeField] private Button[] _buttons;

    private readonly string[] _missions = new string[10]
    {
        "OneMission",
        "TwoMission",
        "ThreeMission",
        "FourMission",
        "FiveMission",
        "SixMission",
        "SevenMission",
        "EightMission",
        "NineMission",
        "TenMission"
    };

    private void OnEnable()
    {
        for (int i = 0; i < _paths.Length; i++)
        {
            _paths[i].Activate(PlayerPrefs.GetInt(_missions[i]));

            if (i != 0)
            {
                if (PlayerPrefs.GetInt(_missions[i - 1]) > 0)
                {
                    _buttons[i].enabled = true;

                    if (PlayerPrefs.GetInt(_missions[i]) == 3)
                    {
                        _yellowIcons[i].SetActive(false);
                        _redIcons[i].SetActive(false);
                        _violetIcons[i].SetActive(true);
                    }
                    else
                    {
                        _yellowIcons[i].SetActive(true);
                        _redIcons[i].SetActive(false);
                        _violetIcons[i].SetActive(false);
                    }
                }
                else
                {
                    _buttons[i].enabled = false;

                    _yellowIcons[i].SetActive(false);
                    _redIcons[i].SetActive(true);
                    _violetIcons[i].SetActive(false);
                }
            }
            else
            {
                if (PlayerPrefs.GetInt(_missions[i]) == 3)
                {
                    _yellowIcons[i].SetActive(false);
                    _redIcons[i].SetActive(false);
                    _violetIcons[i].SetActive(true);
                }
            }
        }
    }
}
