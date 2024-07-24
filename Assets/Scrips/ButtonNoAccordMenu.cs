using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNoAccordMenu : MonoBehaviour
{
    [SerializeField] private GameObject _accordWindow;
    [SerializeField] private GameObject _background;

    public void OnClickButton()
    {
        _accordWindow.SetActive(false);
        _background.SetActive(false);
    }
}
