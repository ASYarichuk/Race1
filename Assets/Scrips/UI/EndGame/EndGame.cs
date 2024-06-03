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
    private int _gold = 0;

    private static readonly List<int> _experiencePlace = new()
    {
        5,
        10,
        25,
        50
    };

    private static readonly List<int> _goldPlace = new()
    {
        500,
        1000,
        2500,
        5000
    };

    private void OnEnable()
    {
        Time.timeScale = 0f;
        _place = _circleCounter.GivePlace();
        _finishText.text = $"Гонка завершилась. Ты занял {_place} место.";

        AddExperience();
        AddGold();
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

    private void AddGold()
    {
        switch (_place)
        {
            case 0:
                break;
            case 1:
                _gold = _goldPlace[3];
                break;
            case 2:
                _gold = _goldPlace[2];
                break;
            case 3:
                _gold = _goldPlace[1];
                break;
            case 4:
                _gold = _goldPlace[0];
                break;
        }

        PlayerGold.AddGold(_gold);
    }
}
