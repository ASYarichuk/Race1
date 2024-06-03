using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RewarderChest : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _textsName;
    [SerializeField] private Image[] _images;
    [SerializeField] private GameObject[] _levelsFull;
    [SerializeField] private TMP_Text[] _textsLevel;
    [SerializeField] private Slider[] _sliders;
    [SerializeField] private TMP_Text[] _textsSlider;
    [SerializeField] private ActivatorStars[] _stars;

    [SerializeField] private ListCardForReward _listCardForReward;
    [SerializeField] private Image _gold;

    private bool _isCard = true;

    private readonly int _maxCountStar = 5;

    public void SetReward(int[] countStar, int[] countCard)
    {
        for (int i = 0; i < _textsName.Length; i++)
        {
            FillCardReward(i, countStar[i], countCard[i]);
        }
    }

    private void FillCardReward(int indexPlaceReward, int countStar, int countCard) 
    {
        CardsForReward cardsForReward = null;

        for (int i = 0; i < _maxCountStar; i++)
        {
            cardsForReward = _listCardForReward.GivePackOfCards(countStar);

            if (cardsForReward.GiveCountCards() == 0 && countStar != 0)
            {
                countStar++;
            }

            if (countStar > _maxCountStar)
            {
                countStar = _maxCountStar;
                _isCard = false;
            }
        }

        if (_isCard)
        {
            _sliders[indexPlaceReward].gameObject.SetActive(true);
            _stars[indexPlaceReward].gameObject.SetActive(true);
            _stars[indexPlaceReward].Deactivate();

            int index = Random.Range(0, cardsForReward.GiveCountCards());

            int numberCurrentCard = cardsForReward.GiveSerialNumber(index);

            _levelsFull[indexPlaceReward].SetActive(false);

            _textsName[indexPlaceReward].text = cardsForReward.GiveCardName(index);
            _images[indexPlaceReward].sprite = cardsForReward.GiveImage(index);
            _stars[indexPlaceReward].Activate(cardsForReward.GiveCountStar(index));

            if (countStar == 0)
            {
                FillCar(indexPlaceReward, numberCurrentCard, countCard);
            }
            else
            {
                FillWeapon(indexPlaceReward, numberCurrentCard, countCard, cardsForReward);
            }
        }
        else
        {
            _images[indexPlaceReward].sprite = _gold.sprite;
            _textsName[indexPlaceReward].text = "200";
            _sliders[indexPlaceReward].gameObject.SetActive(false);
            _stars[indexPlaceReward].gameObject.SetActive(false);
            _isCard = true;
        }
    }

    private void FillWeapon(int indexPlaceReward, int numberCurrentCard, int countCard, CardsForReward cardsForReward)
    {
        ListOfCardsWeapon.AddCard(numberCurrentCard, countCard);

        _textsSlider[indexPlaceReward].text = $"{ListOfCardsWeapon.GiveCurrentCount(numberCurrentCard)}/{ListOfCardsWeapon.GiveMaxCount(numberCurrentCard)}";
        _sliders[indexPlaceReward].value = ListOfCardsWeapon.GiveCurrentCount(numberCurrentCard);
        _sliders[indexPlaceReward].maxValue = ListOfCardsWeapon.GiveMaxCount(numberCurrentCard);
        _textsLevel[indexPlaceReward].text = $"{ListOfCardsWeapon.GiveLevelCard(numberCurrentCard)}";

        if (ListOfCardsWeapon.GiveStatusMaxLevel(numberCurrentCard))
        {
            _levelsFull[indexPlaceReward].SetActive(true);
            _textsSlider[indexPlaceReward].text = $"MAX!";
            _sliders[indexPlaceReward].value = 1;
            _sliders[indexPlaceReward].maxValue = 1;
            cardsForReward.DeleteCard(numberCurrentCard);
        }
    }
    
    private void FillCar(int indexPlaceReward, int numberCurrentCard, int countCard)
    {
        ListOfCardsCar.AddCard(numberCurrentCard, countCard);

        _textsSlider[indexPlaceReward].text = $"{ListOfCardsCar.GiveCurrentCount(numberCurrentCard)}/{ListOfCardsCar.GiveMaxCount(numberCurrentCard)}";
        _sliders[indexPlaceReward].value = ListOfCardsCar.GiveCurrentCount(numberCurrentCard);
        _sliders[indexPlaceReward].maxValue = ListOfCardsCar.GiveMaxCount(numberCurrentCard);
        _textsLevel[indexPlaceReward].text = $"{ListOfCardsCar.GiveLevelCard(numberCurrentCard)}";

        if (ListOfCardsCar.GiveStatusMaxLevel(numberCurrentCard))
        {
            _levelsFull[indexPlaceReward].SetActive(true);
            _textsSlider[indexPlaceReward].text = $"MAX!";
            _sliders[indexPlaceReward].value = 1;
            _sliders[indexPlaceReward].maxValue = 1;
        }
    }
}
