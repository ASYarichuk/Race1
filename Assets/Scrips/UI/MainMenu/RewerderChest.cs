using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RewerderChest : MonoBehaviour
{
    [SerializeField] private TMP_Text _textNameOne;
    [SerializeField] private Image _imageOne;
    [SerializeField] private GameObject _levelFullOne;
    [SerializeField] private TMP_Text _textLevelOne;
    [SerializeField] private Slider _sliderOne;
    [SerializeField] private TMP_Text _textSliderOne;
    [SerializeField] private ActivatorStars _starsOne;

    private int[] _cars = new int[8];
    private int[] _weaponsOneStar = new int[4] { 0, 5, 10, 15 };
    private int[] _weaponsTwoStar = new int[4] { 1, 6, 11, 16 };
    private int[] _weaponsThreeStar = new int[4] { 2, 7, 12, 17 };
    private int[] _weaponsFourStar = new int[4] { 3, 8, 13, 18 };
    private int[] _weaponsFiveStar = new int[5] { 4, 9, 14, 19, 20 };

/*    public Card GiveCarCard()
    {
        int index = Random.Range(0, _cars.Length);

        return ListOfCardsCar.;
    }

    public Card GiveWeaponsOneStar(int index)
    {
        return _weaponsOneStar[index];
    }

    public Card GiveWeaponsTwoStar(int index)
    {
        return _weaponsTwoStar[index];
    }

    public Card GiveWeaponsThreeStar(int index)
    {
        return _weaponsThreeStar[index];
    }

    public Card GiveWeaponsFourStar(int index)
    {
        return _weaponsFourStar[index];
    }

    public Card GiveWeaponsFiveStar(int index)
    {
        return _weaponsFiveStar[index];
    }*/
}
