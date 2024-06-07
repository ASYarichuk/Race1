using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetterImageWeapon : MonoBehaviour
{
    [SerializeField] private Image[] _images;

    private int _currentImage;

    public void SetCurrentImage(int index)
    {
        _currentImage = index;
    }

    public void SetImage(Sprite sprite)
    {
        _images[_currentImage].sprite = sprite;
    }
}
