using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChestsMenu : MonoBehaviour
{
    [SerializeField] private List<Image> _chestsImage;
    [SerializeField] private ListOfChests _listOfChests;

    private void Update()
    {
        for (int i = 0; i < _chestsImage.Count; i++)
        {
            if (PlayerChest.GiveChest(i) != null)
            {
                _chestsImage[i].sprite = PlayerChest.GiveChest(i).GetComponent<Image>().sprite;
            }
            else
            {
                _chestsImage[i].sprite = _listOfChests.GiveVoidChest();
            }
        }
    }

    private void OnEnable()
    {
        if (PlayerChest.TempChest != null)
        {
            PlayerChest.AddChest();
            PlayerChest.SetTempChest(null);
        }
    }

    public void RemoveChest(int index)
    {
        _chestsImage[index].sprite = PlayerChest.GiveChest(index).GetComponent<Image>().sprite;
    }
}
