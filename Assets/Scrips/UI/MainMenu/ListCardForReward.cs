using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ListCardForReward : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _textsName; 
    [SerializeField] private Image[] _images; 
    [SerializeField] private int _countStars;

    private int[] _cards;

    public string GiveCardName(int index)
    {
        return _textsName[index].text;
    }
    
    public Sprite GiveImage(int index)
    {
        return _images[index].sprite;
    }
    
    public int GiveCountStar()
    {
        return _countStars;
    }

    public int GiveCountCards()
    {
        return _cards.Length;
    } 

    public int GiveCard(int index)
    {
       return _cards[index];
    }
}
