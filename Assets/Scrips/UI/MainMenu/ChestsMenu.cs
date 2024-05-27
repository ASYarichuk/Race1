using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChestsMenu : MonoBehaviour
{
    [SerializeField] private List<Image> _chestsImage;
    [SerializeField] private ListOfChests _listOfChests;

    private readonly string _chestOne = "ChestOne";
    private readonly string _chestTwo = "ChestTwo";
    private readonly string _chestThree = "ChestThree";
    private readonly string _chestFour = "ChestFour";

    private readonly string _chestOneState = "ChestOneState";
    private readonly string _chestTwoState = "ChestTwoState";
    private readonly string _chestThreeState = "ChestThreeState";
    private readonly string _chestFourState = "ChestFourState";

    private void Update()
    {
        SetSprite();
    }

    private void SetSprite()
    {
        if (PlayerPrefs.HasKey(_chestOne))
        {
            if (PlayerPrefs.GetInt(_chestOneState) == 0)
            {
                _chestsImage[0].sprite = _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestOne)).GetComponent<Image>().sprite;
            }
            else
            {
                _chestsImage[0].sprite = _listOfChests.GiveOpenChest(PlayerPrefs.GetInt(_chestOne));
            }
        }

        if (PlayerPrefs.HasKey(_chestTwo))
        {
            if (PlayerPrefs.GetInt(_chestTwoState) == 0)
            {
                _chestsImage[1].sprite = _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestTwo)).GetComponent<Image>().sprite;
            }
            else
            {
                _chestsImage[1].sprite = _listOfChests.GiveOpenChest(PlayerPrefs.GetInt(_chestTwo));
            }
        }

        if (PlayerPrefs.HasKey(_chestThree))
        {
            if (PlayerPrefs.GetInt(_chestThreeState) == 0)
            {
                _chestsImage[2].sprite = _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestThree)).GetComponent<Image>().sprite;
            }
            else
            {
                _chestsImage[2].sprite = _listOfChests.GiveOpenChest(PlayerPrefs.GetInt(_chestThree));
            }
        }

        if (PlayerPrefs.HasKey(_chestFour))
        {
            if (PlayerPrefs.GetInt(_chestFourState) == 0)
            {
                _chestsImage[3].sprite = _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestFour)).GetComponent<Image>().sprite;
            }
            else
            {
                _chestsImage[3].sprite = _listOfChests.GiveOpenChest(PlayerPrefs.GetInt(_chestFour));
            }
        }
    }
}
