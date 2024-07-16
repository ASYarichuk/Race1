using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGame : MonoBehaviour
{
    [SerializeField] private GameObject _loseWindow;

    public void EnableWindow()
    {
        _loseWindow.SetActive(true);
    }
}
