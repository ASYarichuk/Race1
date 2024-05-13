using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChestsMenu : MonoBehaviour
{
    [SerializeField] private List<Image> _chestsImage;

    [SerializeField] private int _countChest;

    private void Update()
    {
        _countChest = PlayerChest.CurrentCount;
    }

    private void OnEnable()
    {
        if (PlayerChest.TempChest != null)
        {
            PlayerChest.AddChest();
            PlayerChest.SetTempChest(null);
        }

        for (int i = 0; i < _chestsImage.Count; i++)
        {
            if (PlayerChest.GiveChest(i) != null)
            {
                _chestsImage[i].sprite = PlayerChest.GiveChest(i).GetComponent<Image>().sprite;
            }
        }
    }
}
