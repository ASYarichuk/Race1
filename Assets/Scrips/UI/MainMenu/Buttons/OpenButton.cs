using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButton : MonoBehaviour
{
    [SerializeField] private GameObject _newWindow;

    public void OnClickButton()
    {
        _newWindow.SetActive(true);
    }
}
