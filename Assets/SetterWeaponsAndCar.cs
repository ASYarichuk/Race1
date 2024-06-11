using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetterWeaponsAndCar : MonoBehaviour
{
    [SerializeField] private int _indexButton;

    [SerializeField] private GameObject _selectionMenu;
    [SerializeField] private GameObject _currentImage;

    [SerializeField] private GameObject[] _images;
    [SerializeField] private GameObject[] _imagesFrame;
    [SerializeField] private GameObject[] _packCardsGun;
    [SerializeField] private GameObject[] _packCardsRocket;
    [SerializeField] private GameObject[] _packCardsCar;

    [SerializeField] private Image _cardsMine;

    private readonly int _carIndex = 3;
    private readonly int _correctRocketIndex = 10;

    private readonly int[] _countGun = new int[2] { 0, 10 };
    private readonly int[] _countRocket = new int[2] { 10, 20 };
    private readonly int[] _countCar = new int[2] { 0, 8 };

    private readonly string[] _weaponsAndCar = new string[4]
    {
        "Gun",
        "Rocket",
        "Mine",
        "Car"
    };

    private readonly string _currentIndex = "CurrentIndex";

    private void OnEnable()
    {
        for (int i = 0; i < _weaponsAndCar.Length; i++)
        {
            if (i == _indexButton)
            {
                if (i == 0)
                {
                    _currentImage.GetComponent<Image>().sprite = _packCardsGun[PlayerPrefs.GetInt(_weaponsAndCar[i])].GetComponent<Image>().sprite;
                    _currentImage.transform.localPosition = _packCardsGun[PlayerPrefs.GetInt(_weaponsAndCar[i])].transform.localPosition;
                    _currentImage.transform.localScale = _packCardsGun[PlayerPrefs.GetInt(_weaponsAndCar[i])].transform.localScale;
                }
                else if (i == 1)
                {
                    _currentImage.GetComponent<Image>().sprite = _packCardsRocket[PlayerPrefs.GetInt(_weaponsAndCar[i]) - _correctRocketIndex].GetComponent<Image>().sprite;
                    _currentImage.transform.localPosition = _packCardsRocket[PlayerPrefs.GetInt(_weaponsAndCar[i]) - _correctRocketIndex].transform.localPosition;
                    _currentImage.transform.localScale = _packCardsRocket[PlayerPrefs.GetInt(_weaponsAndCar[i]) - _correctRocketIndex].transform.localScale;
                }
                else if (i == 3)
                {
                    _packCardsCar[0].SetActive(false);
                    _packCardsCar[PlayerPrefs.GetInt(_weaponsAndCar[PlayerPrefs.GetInt(_currentIndex)])].SetActive(true);
                }
            }
        }
    }

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
                PlayerPrefs.SetInt(_currentIndex, 0);
                SetActiveImage(_countGun, _packCardsGun);
                break;

            case 1:
                PlayerPrefs.SetInt(_currentIndex, 1);
                SetActiveImage(_countRocket, _packCardsRocket);
                break;

            case 2:
                PlayerPrefs.SetInt(_currentIndex, 2);
                _selectionMenu.SetActive(true);
                _imagesFrame[0].SetActive(true);
                _images[0].GetComponent<Image>().sprite = _cardsMine.sprite;
                _images[0].transform.localPosition = _cardsMine.transform.localPosition;
                _images[0].transform.localScale = _cardsMine.transform.localScale;
                break;

            case 3:
                PlayerPrefs.SetInt(_currentIndex, 3);
                SetActiveImage(_countCar, _packCardsCar);
                break;
        }
    }

    public void SetNewWeapon(GameObject image)
    {
        _currentImage.GetComponent<Image>().sprite = image.GetComponent<Image>().sprite;
        _currentImage.transform.localPosition = image.transform.localPosition;
        _currentImage.transform.localScale = image.transform.localScale;

        PlayerPrefs.SetInt(_weaponsAndCar[PlayerPrefs.GetInt(_currentIndex)], image.GetComponent<SetterCardIndex>().GiveIndex());
    }

    public void SetNewCar(GameObject image)
    {
        for (int i = 0; i < _packCardsCar.Length; i++)
        {
            _packCardsCar[i].SetActive(false);
        }

        _packCardsCar[PlayerPrefs.GetInt(_weaponsAndCar[PlayerPrefs.GetInt(_currentIndex)])].SetActive(false);
        _packCardsCar[image.GetComponent<SetterCardIndex>().GiveIndex()].SetActive(true);

        PlayerPrefs.SetInt(_weaponsAndCar[PlayerPrefs.GetInt(_currentIndex)], image.GetComponent<SetterCardIndex>().GiveIndex());
    }

    private void SetActiveImage(int[] count, GameObject[] _packCards)
    {
        _selectionMenu.SetActive(true);

        int countActiveImage = 0;
        int index = 0;

        if (PlayerPrefs.GetInt(_currentIndex) == _carIndex)
        {
            for (int i = count[0]; i < count[1]; i++)
            {

                ActivatingAndConfiguringImages(countActiveImage, _packCards, index, i);
                countActiveImage++;

                index++;
            }
        }
        else
        {
            for (int i = count[0]; i < count[1]; i++)
            {
                if (ListOfCardsWeapon.GiveStatusStateOpen(i))
                {
                    ActivatingAndConfiguringImages(countActiveImage, _packCards, index, i);
                    countActiveImage++;
                }

                index++;
            }
        }
    }

    private void ActivatingAndConfiguringImages(int countActiveImage, GameObject[] _packCards, int index, int i)
    {
        _imagesFrame[countActiveImage].SetActive(true);
        _images[countActiveImage].GetComponent<SetterCardIndex>().SetIndex(i);
        _images[countActiveImage].transform.localPosition = _packCards[index].transform.localPosition;
        _images[countActiveImage].transform.localScale = _packCards[index].transform.localScale;
        _images[countActiveImage].GetComponent<Image>().sprite = _packCards[index].GetComponent<Image>().sprite;
    }
}
