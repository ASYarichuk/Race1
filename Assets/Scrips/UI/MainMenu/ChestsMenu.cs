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

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey(_chestOne))
        {
            _chestsImage[0].sprite = _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestOne)).GetComponent<Image>().sprite;
            Debug.Log("ChestOne");
        }

        if (PlayerPrefs.HasKey(_chestTwo))
        {
            _chestsImage[1].sprite = _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestTwo)).GetComponent<Image>().sprite;
            Debug.Log("ChestTwo");
        }
        
        if (PlayerPrefs.HasKey(_chestThree))
        {
            _chestsImage[2].sprite = _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestThree)).GetComponent<Image>().sprite;
            Debug.Log("ChestThree");
        }
        
        if (PlayerPrefs.HasKey(_chestFour))
        {
            _chestsImage[3].sprite = _listOfChests.GiveCloseChest(PlayerPrefs.GetInt(_chestFour)).GetComponent<Image>().sprite;
            Debug.Log("ChestFour");
        }
    }
}
