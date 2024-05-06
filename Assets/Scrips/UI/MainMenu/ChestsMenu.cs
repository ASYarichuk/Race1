using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestsMenu : MonoBehaviour
{
    [SerializeField] private ListOfChests _listOfChests;
    [SerializeField] private List<Chest> _chests;

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
        for (int i = 0; i < _chests.Count && _isFindVoidPlace == false; i++)
        {
            if (_chests[i].GiveState())
            {
                AddChest(indexChest, i);
                _isFindVoidPlace = true;
            }
        }
    }

    private void AddChest(int indexChest, int indexCurrentPlace)
    {
        _chests[indexCurrentPlace].GetComponent<Image>().sprite = _listOfChests.GiveCloseChest(indexChest);
    }
}
