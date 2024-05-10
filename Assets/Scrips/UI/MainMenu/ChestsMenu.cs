using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChestsMenu : MonoBehaviour
{
    [SerializeField] private List<Image> _chestsImage;
    [SerializeField] private List<Table> _tables;

    [SerializeField] private int _countChest;

    private void Update()
    {
        _countChest = PlayerChest.CurrentCount;
    }

    private void OnEnable()
    {
        if(PlayerChest.TempChest != null)
        {
            PlayerChest.AddChest(_tables);
        }

        for (int i = 0; i < _chestsImage.Count; i++)
        {
            if (PlayerChest.GiveChest(i) != null && PlayerChest.GiveChest(i).TryGetComponent(out Image image))
            {
                _chestsImage[i].sprite = image.sprite;
            }
        }
    }
}
