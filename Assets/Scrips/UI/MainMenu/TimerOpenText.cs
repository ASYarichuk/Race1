using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerOpenText : MonoBehaviour
{
    private static GameObject _currentObject;

    private float _timeOpen = 100;

    private void Awake()
    {
        if (_currentObject != null)
        {
            if (_currentObject != gameObject)
            {
                Destroy(gameObject);
            }
        }

        _currentObject = gameObject;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        _timeOpen -= Time.deltaTime;
    }

    public float GiveTimer()
    {
        return _timeOpen;
    }
}
