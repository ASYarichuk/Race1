using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetterWeapons : MonoBehaviour
{
    [SerializeField] private int _indexButton;

    [SerializeField] private GameObject _selectionMenu;

    [SerializeField] private GameObject[] _imagesWeapon;
    [SerializeField] private GameObject[] _imagesFrame;

    [SerializeField] private Image[] _packCardsGun;
    [SerializeField] private Image[] _packCardsMortal;
    [SerializeField] private Image[] _packCardsRocket;
    [SerializeField] private Image _cardsMine;

    private int[] _countGun = new int[2] { 0,10};
    private int[] _countMortar = new int[2] { 10, 15 };
    private int[] _countRocket = new int[2] { 15, 20 };

    private void OnDisable()
    {
        for (int i = 0; i < _imagesFrame.Length; i++)
        {
            _imagesFrame[i].SetActive(false);
        }
    }

    public void OnClickButton()
    {
        switch (_indexButton)
        {
            case 0:
                SetActiveImage(_countGun, _packCardsGun);
                break;

            case 1:
                SetActiveImage(_countMortar, _packCardsMortal);
                break;

            case 2:
                SetActiveImage(_countRocket, _packCardsRocket);
                break;

            case 3:
                _selectionMenu.SetActive(true);
                _imagesFrame[0].SetActive(true);
                _imagesWeapon[0].GetComponent<Image>().sprite = _cardsMine.sprite;
                break;
        }
    }

    private void SetActiveImage(int[] count, Image[] _packCards)
    {
        _selectionMenu.SetActive(true);

        int countActiveImage = 0;
        int index = 0;

        for (int i = count[0]; i < count[1] - count[0]; i++)
        {
            if (ListOfCardsWeapon.GiveStatusStateOpen(i))
            {
                _imagesFrame[countActiveImage].SetActive(true);
                _imagesWeapon[countActiveImage].GetComponent<Image>().sprite = _packCards[index].sprite;
                countActiveImage++;
            }

            index++;
        }
    }
}
