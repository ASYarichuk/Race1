using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardExp : MonoBehaviour
{
    [SerializeField] private TMP_Text _level;
    [SerializeField] private TMP_Text _experience;
    [SerializeField] private TMP_Text _rewardExperience;
    [SerializeField] private Slider _slider;

    public void Show(int experience)
    {
        int maxExperience = PlayerLevel.GiveNeedExperience();
        int currentExperience = PlayerLevel.GiveCurrentExperience();

        _level.text = $"{PlayerLevel.Level}";
        _rewardExperience.text = $"+{experience}";
        _experience.text = $"{currentExperience} / {maxExperience}";
        _slider.maxValue = maxExperience;
        _slider.minValue = 0;
        _slider.value = currentExperience;
    }
}
