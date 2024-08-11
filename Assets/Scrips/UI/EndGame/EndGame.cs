using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _finishText;
    [SerializeField] private CircleCounter _circleCounter;
    [SerializeField] private RewardExp _rewardExp;
    [SerializeField] private RewardCups _rewardCups;

    private int _place = 0;
    private int _experience = 0;
    private int _cups = 0;
    private readonly int _correctPlaceStar = 4;

    private readonly string _isMission = "IsMission";
    private readonly string _currentMission = "CurrentMission";

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

    private static readonly List<int> _experiencePlace = new()
    {
        5,
        10,
        25,
        50
    };
    
    private static readonly List<int> _cupsPlace = new()
    {
        1,
        2,
        5,
        10
    };

    private void OnEnable()
    {
        Time.timeScale = 0f;
        _place = _circleCounter.GivePlace();
        _finishText.text = $"Гонка завершилась. Ты занял {_place} место.";

        SetCountStarsForMission();
        AddExperience();
    }

    private void AddExperience()
    {
        switch (_place)
        {
            case 0:
                break;
            case 1:
                _experience = _experiencePlace[3];
                _cups = _cupsPlace[3];
                break;
            case 2:
                _experience = _experiencePlace[2];
                _cups = _cupsPlace[2];
                break;
            case 3:
                _experience = _experiencePlace[1];
                _cups = _cupsPlace[1];
                break;
            case 4:
                _experience = _experiencePlace[0];
                _cups = _cupsPlace[0];
                break;
        }

        _rewardExp.Show(_experience);
        _rewardCups.Show(_cups);
        PlayerLevel.AddExperience(_experience);
    }

    private void SetCountStarsForMission()
    {
        if (PlayerPrefs.GetInt(_isMission) == 1)
        {
            if (PlayerPrefs.GetInt(_missions[PlayerPrefs.GetInt(_currentMission)]) < _correctPlaceStar - _place)
            {
                PlayerPrefs.SetInt(_missions[PlayerPrefs.GetInt(_currentMission)], _correctPlaceStar - _place);
            }
        }

        PlayerPrefs.SetInt(_isMission, 0);
    }
}
