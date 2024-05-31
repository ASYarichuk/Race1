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

    private void OnEnable()
    {
        for (int i = 0; i < _textsName.Length; i++)
        {
            FillCardReward(i);
        }
    }

    private void FillCardReward(int indexPlaceReward)
    {
        int index = Random.Range(0, _listCardForReward.GiveCountCards());

        int numberCurrentCard = _listCardForReward.GiveCard(index);

        _levelsFull[indexPlaceReward].SetActive(false);
        _textsSlider[indexPlaceReward].text = $"{ListOfCardsWeapon.GiveCurrentCount(index)}/{ListOfCardsWeapon.GiveMaxCount(index)}";
        _sliders[indexPlaceReward].value = ListOfCardsWeapon.GiveCurrentCount(index);
        _sliders[indexPlaceReward].maxValue = ListOfCardsWeapon.GiveMaxCount(index);

        if (ListOfCardsWeapon.GiveStatusMaxLevel(numberCurrentCard))
        {
            _levelsFull[indexPlaceReward].SetActive(true);
            _textsSlider[indexPlaceReward].text = $"MAX!";
            _sliders[indexPlaceReward].value = 1;
            _sliders[indexPlaceReward].maxValue = 1;
        }

        _textsLevel[indexPlaceReward].text = $"{ListOfCardsWeapon.GiveLevelCard(index)}";
        _textsName[indexPlaceReward].text = _listCardForReward.GiveCardName(index);
        _images[indexPlaceReward].sprite = _listCardForReward.GiveImage(index);
        _stars[indexPlaceReward].Activate(_listCardForReward.GiveCountStar());
    }
}
