using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _finishText;
    [SerializeField] private CircleCounter _circleCounter;

    private int _place = 0;
    private int _experience = 0;
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
                break;
            case 2:
                _experience = _experiencePlace[2];
                break;
            case 3:
                _experience = _experiencePlace[1];
                break;
            case 4:
                _experience = _experiencePlace[0];
                break;
        }

        PlayerLevel.AddExperience(_experience);
    }

    private void SetCountStarsForMission()
    {
        Debug.Log("SetCountStarsForMission");
        Debug.Log(PlayerPrefs.GetInt(_isMission));
        Debug.Log(PlayerPrefs.GetInt(_missions[PlayerPrefs.GetInt(_currentMission)]));
        Debug.Log(_missions[PlayerPrefs.GetInt(_currentMission)]);
        Debug.Log(PlayerPrefs.GetInt(_currentMission));

        if (PlayerPrefs.GetInt(_isMission) == 1)
        {
            Debug.Log("if_1");
            if (PlayerPrefs.GetInt(_missions[PlayerPrefs.GetInt(_currentMission)]) < _correctPlaceStar - _place)
            {
                Debug.Log("if_2");
                PlayerPrefs.SetInt(_missions[PlayerPrefs.GetInt(_currentMission)], _correctPlaceStar - _place);
            }
        }

        PlayerPrefs.SetInt(_isMission, 0);
    }
}
