using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetterWeapons : MonoBehaviour
{
    [SerializeField] private int _indexButton;

    [SerializeField] private SetterImageWeapon _setterImageWeapon;

    [SerializeField] private GameObject _selectionMenu;

    [SerializeField] private GameObject[] _imagesWeapon;
    [SerializeField] private GameObject[] _imagesFrame;

    [SerializeField] private GameObject[] _packCardsGun;
    [SerializeField] private GameObject[] _packCardsMortal;
    [SerializeField] private GameObject[] _packCardsRocket;
    [SerializeField] private Image _cardsMine;

    private readonly int[] _countGun = new int[2] { 0,10};
    private readonly int[] _countMortar = new int[2] { 10, 15 };
    private readonly int[] _countRocket = new int[2] { 15, 20 };

    public void CloseSelectionMenu()
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
                _setterImageWeapon.SetCurrentImage(0);
                break;

            case 1:
                SetActiveImage(_countMortar, _packCardsMortal);
                _setterImageWeapon.SetCurrentImage(1);
                break;

            case 2:
                SetActiveImage(_countRocket, _packCardsRocket);
                _setterImageWeapon.SetCurrentImage(2);
                break;

            case 3:
                _selectionMenu.SetActive(true);
                _imagesFrame[0].SetActive(true);
                _imagesWeapon[0].GetComponent<Image>().sprite = _cardsMine.sprite;
                _imagesWeapon[0].transform.localPosition = _cardsMine.transform.localPosition;
                _imagesWeapon[0].transform.localScale = _cardsMine.transform.localScale;
                _imagesWeapon[0].GetComponent<Image>().sprite = _cardsMine.GetComponent<Image>().sprite;
                _setterImageWeapon.SetCurrentImage(3);
                break;
        }
    }

    private void SetActiveImage(int[] count, GameObject[] _packCards)
    {
        _selectionMenu.SetActive(true);

        int countActiveImage = 0;
        int index = 0;

        for (int i = count[0]; i < count[1]; i++)
        {
            if (ListOfCardsWeapon.GiveStatusStateOpen(i))
            {
                _imagesFrame[countActiveImage].SetActive(true);
                _imagesWeapon[countActiveImage].transform.localPosition = _packCards[index].transform.localPosition;
                _imagesWeapon[countActiveImage].transform.localScale = _packCards[index].transform.localScale;
                _imagesWeapon[countActiveImage].GetComponent<Image>().sprite = _packCards[index].GetComponent<Image>().sprite;
                countActiveImage++;
            }

            index++;
        }
    }
}
