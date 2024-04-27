using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CircleCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _circleCounter;
    [SerializeField] private int _maxCircle = 3;
    [SerializeField] private int _maxPoint = 4;
    [SerializeField] private SwitchControlPoints _switchControlPoints;
    [SerializeField] private Canvas _endGame;
    [SerializeField] private PlaceTakenInRace _placeTakenInRace;

    private int _currentCircle = 0;
    private int _currentPoint = 0;
    private int _placeInRace;
    private Car _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMover>().GetComponent<Car>();
    }

    private void Update()
    {
        _circleCounter.text = $"������� ����   {_currentCircle} / {_maxCircle} \n�������� ����������� ����� �� �����   {_currentPoint} / {_maxPoint}";
    }

    private void CheckCircle()
    {
        if (_currentCircle == _maxCircle)
        {
            _placeTakenInRace.GetPlace(_player);
            _placeInRace = _placeTakenInRace.GivePlace();
            _endGame.gameObject.SetActive(true);
        }
    }

    public void PointPassed()
    {
        _currentPoint = _switchControlPoints.ActiveNextPoint();

        if (_currentPoint == 0)
        {
            _currentCircle += 1;
        }

        CheckCircle();
    }

    public int GivePlace()
    {
        return _placeInRace;
    }
}
