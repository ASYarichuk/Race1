using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetterWeapons : MonoBehaviour
{
    [SerializeField] private GameObject _selectionMenu;
    [SerializeField] private int _indexButton;
    [SerializeField] private GameObject[] _images;

    private int[] _countGun = new int[2] { 0,10};
    private int[] _countMortar = new int[2] { 10, 15 };
    private int[] _countRocket = new int[2] { 15, 20 };
    private int _countMine = 20;

    public void OnClickButton()
    {
        

        switch (_indexButton)
        {
            case 0:
                SetActiveImage(_countGun);
                break;

            case 1:

                break;

            case 2:

                break;

            case 3:

                break;
        }
    }

    private void SetActiveImage(int[] count)
    {
        int countActiveImage = 0;

        for (int i = count[0]; i < count[1] - count[0]; i++)
        {
            if (ListOfCardsWeapon.GiveStatusStateOpen(i))
            {
                _images[countActiveImage].SetActive(true);
                _images[countActiveImage].GetComponent<Image>().sprite = null;
                countActiveImage++;
            }
        }
    }
}
