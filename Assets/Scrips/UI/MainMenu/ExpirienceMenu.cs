using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpirienceMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _level;
    [SerializeField] private TMP_Text _experience;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        int currentExperience = PlayerLevel.GiveCurrentExperience();
        int maxExperience = PlayerLevel.GiveNeedExperience();

        _level.text = $"{PlayerLevel.Level}";
        _experience.text = $"{currentExperience} / {maxExperience}";
        _slider.value = currentExperience;
        _slider.minValue = 0;
        _slider.maxValue = maxExperience;
    }
}
