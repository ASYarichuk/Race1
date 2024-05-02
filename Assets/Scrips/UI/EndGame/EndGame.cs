using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _finishText;
    [SerializeField] private CircleCounter _circleCounter;

    private int _place = 0;

    private void OnEnable()
    {
        Time.timeScale = 0f;
        _place = _circleCounter.GivePlace();
        _finishText.text = $"Гонка завершилась. Ты занял {_place} место.";
    }
}
