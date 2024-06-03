using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardsForReward : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> _textsName;
    [SerializeField] private List<Image> _images;
    [SerializeField] private List<int> _serialNumber;

    [SerializeField] private int _countStars;
    [SerializeField] private bool _isCar = false;

    public string GiveCardName(int index)
    {
        return _textsName[index].text;
    }

    public Sprite GiveImage(int index)
    {
        return _images[index].sprite;
    }

    public int GiveCountCards()
    {
        return _textsName.Count;
    }

    public int GiveCountStar(int index)
    {
        if (_isCar)
        {
            _countStars = ListOfCardsCar.GiveCurrentStars(_serialNumber[index]);
        }

        return _countStars;
    }

    public int GiveSerialNumber(int index)
    {
        return _serialNumber[index];
    }

    public void DeleteCard(int serialNumber)
    {
        for (int i = 0; i < _serialNumber.Count; i++)
        {
            if (serialNumber == _serialNumber[i])
            {
                Debug.Log($"{_serialNumber[i]} + {_textsName[i].text}");
                _serialNumber.RemoveAt(i);
                _textsName.RemoveAt(i);
                _images.RemoveAt(i);
            }
        }
    }
}
