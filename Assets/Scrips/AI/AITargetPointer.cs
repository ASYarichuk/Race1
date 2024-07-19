using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITargetPointer : MonoBehaviour
{
    private ControllerPoints _controllerPoints;

    [SerializeField] private int _currentNumberPoint = 0;

    [SerializeField] private Vector3 _currentTarget;

    [SerializeField] private float _distanceToPoint;

    private int _maxCountPoint;

    private void Awake()
    {
        _controllerPoints = FindObjectOfType<ControllerPoints>();
        _currentTarget = _controllerPoints.SetPoint(_currentNumberPoint);
        _maxCountPoint = _controllerPoints.MaxCountPoint();
        _currentNumberPoint++;
    }

    private void Update()
    {
        CheckCurrentTarget();
    }

    private void CheckCurrentTarget()
    {
        if (Vector3.Distance(transform.position, _currentTarget) < _distanceToPoint)
        {
            _currentTarget = _controllerPoints.SetPoint(_currentNumberPoint);
            _currentNumberPoint++;

            if (_currentNumberPoint >= _maxCountPoint)
            {
                _currentNumberPoint = 0;
            }
        }
    }

    public Vector3 SetTarget()
    {
        return _currentTarget;
    }
}
