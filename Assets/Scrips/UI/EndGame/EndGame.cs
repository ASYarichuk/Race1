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
}
