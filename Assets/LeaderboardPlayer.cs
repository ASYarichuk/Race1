using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardPlayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject _leaderboardWindow;

    private string _countCups = "CountCups";

    private int _minCups = 0;

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey(_countCups))
        {
            PlayerPrefs.SetInt(_countCups, _minCups);
        }

        _text.text = $"Количество кубков: {PlayerPrefs.GetInt(_countCups)}";
    }

    public void OnClickButton()
    {
        _leaderboardWindow.SetActive(true);
    }
}
