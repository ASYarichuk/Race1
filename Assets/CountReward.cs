using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountReward : MonoBehaviour
{
    private readonly string[] _chestsName = new string[4]
    {
        "ChestOne",
        "ChestTwo",
        "ChestThree",
        "ChestFour"
    };

    private readonly int _usualChest = 0;
    private readonly int _rareChest = 1;
    private readonly int _epicChest = 2;
    private readonly int _mythicalChest = 3;
    private readonly int _legendaryChest = 4;

    private readonly int _carCard = 0;
    private readonly int _oneStarCard = 1;
    private readonly int _twoStarCard = 2;
    private readonly int _threeStarCard = 3;
    private readonly int _fourStarCard = 4;
    private readonly int _fiveStarCard = 5;

    private readonly int[] _usualChestCountCard = new int[2] { 1, 21 };
    private readonly int _usualChestPercentCarCard = 31;

    private readonly int[] _rareChestCountCardOneStar = new int[2] { 20, 41 };
    private readonly int[] _rareChestCountCardTwoStar = new int[2] { 5, 21 };
    private readonly int _rareChestPercentCarCard = 31;
    private readonly int _rareChestPercentCarOneStar = 91;

    private readonly int[] _epicChestCountCardOneStar = new int[2] { 40, 81 };
    private readonly int[] _epicChestCountCardTwoStar = new int[2] { 20, 41 };
    private readonly int[] _epicChestCountCardThreeStar = new int[2] { 10, 26 };
    private readonly int _epicChestPercentCarCard = 31;
    private readonly int _epicChestPercentCarOneStar = 81;
    private readonly int _epicChestPercentCarTwoStar = 96;

    private readonly int[] _mythicalChestCountCardOneStar = new int[2] { 60, 121 };
    private readonly int[] _mythicalChestCountCardTwoStar = new int[2] { 40, 81 };
    private readonly int[] _mythicalChestCountCardThreeStar = new int[2] { 25, 46 };
    private readonly int[] _mythicalChestCountCardFourStar = new int[2] { 15, 36 };
    private readonly int _mythicalChestPercentCarCard = 31;
    private readonly int _mythicalChestPercentCarOneStar = 73;
    private readonly int _mythicalChestPercentCarTwoStar = 88;
    private readonly int _mythicalChestPercentCarThreeStar = 98;

    private readonly int[] _legendaryChestCountCardOneStar = new int[2] { 100, 151 };
    private readonly int[] _legendaryChestCountCardTwoStar = new int[2] { 80, 151 };
    private readonly int[] _legendaryChestCountCardThreeStar = new int[2] { 60, 121 };
    private readonly int[] _legendaryChestCountCardFourStar = new int[2] { 40, 121 };
    private readonly int[] _legendaryChestCountCardFiveStar = new int[2] { 25, 66 };
    private readonly int _legendaryChestPercentCarCard = 4; //26
    private readonly int _legendaryChestPercentCarOneStar = 10; // 51
    private readonly int _legendaryChestPercentCarTwoStar = 21; // 71
    private readonly int _legendaryChestPercentCarThreeStar = 51; //91
    private readonly int _legendaryChestPercentCarFourStar = 70; //100

    public int[] GiveCountStarAndCard(int index)
    {
        int[] current = GiveCount(index);

        int countsStar = current[0];
        int countsCard = current[1];

        return new int[2] { countsStar, countsCard };
    }

    private int[] GiveCount(int index)
    {
        int currentCountStar = 0;
        int currentCountCard = 0;

        int currentPercent = Random.Range(0, 101);

        Debug.Log(currentPercent);

        if (PlayerPrefs.GetInt(_chestsName[index]) == _usualChest)
        {
            if (currentPercent < _usualChestPercentCarCard)
            {
                currentCountStar = _carCard;
            }
            else
            {
                currentCountStar = _oneStarCard;
            }

            currentCountCard = Random.Range(_usualChestCountCard[0], _usualChestCountCard[1]);
        }
        else if (PlayerPrefs.GetInt(_chestsName[index]) == _rareChest)
        {
            if (currentPercent < _rareChestPercentCarCard)
            {
                currentCountStar = _carCard;
                currentCountCard = Random.Range(_rareChestCountCardOneStar[0], _rareChestCountCardOneStar[1]);
            }
            else if (currentPercent < _rareChestPercentCarOneStar)
            {
                currentCountStar = _oneStarCard;
                currentCountCard = Random.Range(_rareChestCountCardOneStar[0], _rareChestCountCardOneStar[1]);
            }
            else
            {
                currentCountStar = _twoStarCard;
                currentCountCard = Random.Range(_rareChestCountCardTwoStar[0], _rareChestCountCardTwoStar[1]);
            }
        }
        else if (PlayerPrefs.GetInt(_chestsName[index]) == _epicChest)
        {
            if (currentPercent < _epicChestPercentCarCard)
            {
                currentCountStar = _carCard;
                currentCountCard = Random.Range(_epicChestCountCardOneStar[0], _epicChestCountCardOneStar[1]);
            }
            else if (currentPercent < _epicChestPercentCarOneStar)
            {
                currentCountStar = _oneStarCard;
                currentCountCard = Random.Range(_epicChestCountCardOneStar[0], _epicChestCountCardOneStar[1]);
            }
            else if (currentPercent < _epicChestPercentCarTwoStar)
            {
                currentCountStar = _twoStarCard;
                currentCountCard = Random.Range(_epicChestCountCardTwoStar[0], _epicChestCountCardTwoStar[1]);
            }
            else
            {
                currentCountStar = _threeStarCard;
                currentCountCard = Random.Range(_epicChestCountCardThreeStar[0], _epicChestCountCardThreeStar[1]);
            }
        }
        else if (PlayerPrefs.GetInt(_chestsName[index]) == _mythicalChest)
        {
            if (currentPercent < _mythicalChestPercentCarCard)
            {
                currentCountStar = _carCard;
                currentCountCard = Random.Range(_mythicalChestCountCardOneStar[0], _mythicalChestCountCardOneStar[1]);
            }
            else if (currentPercent < _mythicalChestPercentCarOneStar)
            {
                currentCountStar = _oneStarCard;
                currentCountCard = Random.Range(_mythicalChestCountCardOneStar[0], _mythicalChestCountCardOneStar[1]);
            }
            else if (currentPercent < _mythicalChestPercentCarTwoStar)
            {
                currentCountStar = _twoStarCard;
                currentCountCard = Random.Range(_mythicalChestCountCardTwoStar[0], _mythicalChestCountCardTwoStar[1]);
            }
            else if (currentPercent < _mythicalChestPercentCarThreeStar)
            {
                currentCountStar = _threeStarCard;
                currentCountCard = Random.Range(_mythicalChestCountCardThreeStar[0], _mythicalChestCountCardThreeStar[1]);
            }
            else
            {
                currentCountStar = _fourStarCard;
                currentCountCard = Random.Range(_mythicalChestCountCardFourStar[0], _mythicalChestCountCardFourStar[1]);
            }
        }
        else if (PlayerPrefs.GetInt(_chestsName[index]) == _legendaryChest)
        {
            if (currentPercent < _legendaryChestPercentCarCard)
            {
                currentCountStar = _carCard;
                currentCountCard = Random.Range(_legendaryChestCountCardOneStar[0], _legendaryChestCountCardOneStar[1]);
            }
            else if (currentPercent < _legendaryChestPercentCarOneStar)
            {
                currentCountStar = _oneStarCard;
                currentCountCard = Random.Range(_legendaryChestCountCardOneStar[0], _legendaryChestCountCardOneStar[1]);
            }
            else if (currentPercent < _legendaryChestPercentCarTwoStar)
            {
                currentCountStar = _twoStarCard;
                currentCountCard = Random.Range(_legendaryChestCountCardTwoStar[0], _legendaryChestCountCardTwoStar[1]);
            }
            else if (currentPercent < _legendaryChestPercentCarThreeStar)
            {
                currentCountStar = _threeStarCard;
                currentCountCard = Random.Range(_legendaryChestCountCardThreeStar[0], _legendaryChestCountCardThreeStar[1]);
            }
            else if (currentPercent < _legendaryChestPercentCarFourStar)
            {
                currentCountStar = _fourStarCard;
                currentCountCard = Random.Range(_legendaryChestCountCardFourStar[0], _legendaryChestCountCardFourStar[1]);
            }
            else
            {
                currentCountStar = _fiveStarCard;
                currentCountCard = Random.Range(_legendaryChestCountCardFiveStar[0], _legendaryChestCountCardFiveStar[1]);
            }
        }

        int[] reward = new int[2] { currentCountStar, currentCountCard };
        return reward;
    }
}
