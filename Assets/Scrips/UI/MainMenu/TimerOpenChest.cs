using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerOpenChest : MonoBehaviour
{
    private float _timeOpen = 0;

    private void Update()
    {
        _timeOpen -= Time.deltaTime;

        if (_timeOpen <= 0)
        {
            Debug.Log(0);
            if (PlayerChest.GiveChest(0) != null)
            {
                Debug.Log(1);
                _timeOpen = PlayerChest.GiveChest(0).GetComponent<Chest>().GiveTimeOpened();
            }
            else
            {
                Debug.Log(2);
                _timeOpen = 0;
            }
        }  
    }

    public float GiveTimer()
    {
        return _timeOpen;
    }
}
