using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChestsMenu : MonoBehaviour
{
    [SerializeField] private ListOfChests _listOfChests;
    [SerializeField] private List<Image> _chestsImage;

    [SerializeField] private List<Sprite> _saveChests;

    private string _nameMainScene = "MainMenu";

    private int _currentCount = 0;
    private int _maxCount = 4;

    private bool _isFindVoidPlace = false;

    private static GameObject sampleInstance;

    private void Awake()
    {
        if (sampleInstance != null)
            Destroy(sampleInstance);

        sampleInstance = gameObject;
        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().name == _nameMainScene)
        {
            for (int i = 0; i < _chestsImage.Count; i++)
            {
                _chestsImage[i].GetComponent<Image>().sprite = _saveChests[i];
            }
        }

        if (PlayerChest.GivenChest)
        {
            if (_currentCount < _maxCount)
            {
                CheckChests(PlayerChest.GiveChest());
                _isFindVoidPlace = false;
                _currentCount++;
            }
        }
    }

    private void CheckChests(int indexChest)
    {
        for (int i = 0; i < _chestsImage.Count && _isFindVoidPlace == false; i++)
        {
            /*if (_chestsImage[i].GiveState())
            {
                AddChest(indexChest, i);
                _isFindVoidPlace = true;
                _chestsImage[i].ChangeState();
            }*/
        }
    }

    private void AddChest(int indexChest, int indexCurrentPlace)
    {
        _chestsImage[indexCurrentPlace].GetComponent<Image>().sprite = _listOfChests.GiveCloseChest(indexChest);
        _saveChests[indexCurrentPlace] = _listOfChests.GiveCloseChest(indexChest);
    }
}
