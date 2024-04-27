using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoicerAvatar : MonoBehaviour
{
    [SerializeField] private GameObject _avatars;
    [SerializeField] private Image _currentAvatar;
    [SerializeField] private Image _avatar;

    public void OnClickButton()
    {
        _currentAvatar.sprite = _avatar.sprite;
        _avatars.SetActive(false);
    }
}

