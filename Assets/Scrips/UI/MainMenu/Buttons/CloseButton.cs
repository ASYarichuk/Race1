using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField] private GameObject _startMenu;

    private GameObject _currentWindow;

    private void Awake()
    {
        _currentWindow = GetComponentInParent<Window>().gameObject;
    }

    public void OnClickButton()
    {
        _startMenu.SetActive(true);
        _currentWindow.SetActive(false);    
    }
}
