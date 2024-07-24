using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private GameObject _accordWindow;
    [SerializeField] private GameObject _background;

    public void OnClickButton()
    {
        _accordWindow.SetActive(true);
        _background.SetActive(true);
    }
}
