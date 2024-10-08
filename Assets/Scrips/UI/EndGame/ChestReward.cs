using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestReward : MonoBehaviour
{
    [SerializeField] private ListOfChests _listOfChests;
    [SerializeField] private Image _chest;

    private readonly int _maxPercent = 100;
    private readonly int _percentChestTwo = 51;
    private readonly int _percentChestThree = 26;
    private readonly int _percentChestFour = 11;
    private readonly int _percentChestFive = 3;
    private int indexChest = 0;

    private void OnEnable()
    {
        int percent = Random.Range(0, _maxPercent);

        if (percent < _percentChestFive)
        {
            indexChest = 4;
        }
        else if (percent < _percentChestFour)
        {
            indexChest = 3;
        }
        else if (percent < _percentChestThree)
        {
            indexChest = 2;
        }
        else if (percent < _percentChestTwo)
        {
            indexChest = 1;
        }
        else
        {
            indexChest = 0;
        }

        GameObject tempChest = _listOfChests.GiveCloseChest(indexChest);
        _chest.sprite = tempChest.GetComponent<Image>().sprite;

        if (PlayerPrefs.HasKey("ChestOne") == false)
        {
            PlayerPrefs.SetInt("ChestOne", indexChest);
            PlayerPrefs.SetInt("ChestOneState", 0);
        }
        else if (PlayerPrefs.HasKey("ChestTwo") == false)
        {
            PlayerPrefs.SetInt("ChestTwo", indexChest);
            PlayerPrefs.SetInt("ChestTwoState", 0);
        }
        else if (PlayerPrefs.HasKey("ChestThree") == false)
        {
            PlayerPrefs.SetInt("ChestThree", indexChest);
            PlayerPrefs.SetInt("ChestThreeState", 0);
        }
        else if (PlayerPrefs.HasKey("ChestFour") == false)
        {
            PlayerPrefs.SetInt("ChestFour", indexChest);
            PlayerPrefs.SetInt("ChestFourState", 0);
        }
    }
}
