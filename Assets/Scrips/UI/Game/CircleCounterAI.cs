using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCounterAI : MonoBehaviour
{
    private PlaceTakenInRace _placeTakenInRace;
    private CircleCounter _circleCounter;

   private int _maxCircle = 3;
     private int _maxPoint = 4;

    private int _currentCircle = 0;
    private int _currentPoint = 0;

    private void Awake()
    {
        _placeTakenInRace = FindObjectOfType<PlaceTakenInRace>();
        _circleCounter = FindObjectOfType<CircleCounter>();

        int[] maxPointAndCircle = _circleCounter.GiveCountPointAndCircle();
        _maxPoint = maxPointAndCircle[0];
        _maxCircle = maxPointAndCircle[0];
    }

    public void PointPassed()
    {
        _currentPoint += 1;

        if (_currentPoint >= _maxPoint)
        {
            _currentCircle += 1;
            _currentPoint = 0;
        }

        if (_currentCircle == _maxCircle)
        {
            _placeTakenInRace.GetPlace(GetComponent<Car>());
        }
    }
}
