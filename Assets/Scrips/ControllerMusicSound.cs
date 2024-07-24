using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerMusicSound : MonoBehaviour
{
    [SerializeField] private Slider _sliderMusic;
    [SerializeField] private Slider _sliderSound;
    
    [SerializeField] private Toggle _toggleMusic;
    [SerializeField] private Toggle _toggleSound;

    public static event Action ChangeValueMusic;
    public static event Action ChangeValueSound;
    
    public static event Action ChangeIsMusic;
    public static event Action ChangeIsSound;

    private readonly string _valueMusic = "ValueMusic";
    private readonly string _valueSound = "ValueSound";
    
    private readonly string _isMusic = "IsMusic";
    private readonly string _isSound = "IsSound";

    private float _oldValueMusic;
    private float _oldValueSound;

    private readonly float _maxValue = 1;

    private readonly int _trueValue = 1;
    private readonly int _falseValue = 0;

    private void Start()
    {
        if (PlayerPrefs.HasKey(_valueMusic) == false)
        {
            PlayerPrefs.SetFloat(_valueMusic, _maxValue);
            _sliderMusic.value = PlayerPrefs.GetFloat(_valueMusic);
        }
        else
        {
            _sliderMusic.value = PlayerPrefs.GetFloat(_valueMusic);
        }
        
        if (PlayerPrefs.HasKey(_valueSound) == false)
        {
            PlayerPrefs.SetFloat(_valueSound, _maxValue);
            _sliderSound.value = PlayerPrefs.GetFloat(_valueSound);
        }
        else
        {
            _sliderSound.value = PlayerPrefs.GetFloat(_valueSound);
        }

        _oldValueMusic = PlayerPrefs.GetFloat(_valueMusic);
        _oldValueSound = PlayerPrefs.GetFloat(_valueSound);

        if (PlayerPrefs.HasKey(_isMusic) == false)
        {
            PlayerPrefs.SetInt(_isMusic, _trueValue);
            _toggleMusic.isOn = false;
        }
        else
        {
            if (PlayerPrefs.GetInt(_isMusic) == _trueValue)
            {
                _toggleMusic.isOn = false;
            }
            else
            {
                _toggleMusic.isOn = true;
            }   
        }
        
        if (PlayerPrefs.HasKey(_isSound) == false)
        {
            PlayerPrefs.SetInt(_isSound, _trueValue);
            _toggleSound.isOn = false;
        }
        else
        {
            if (PlayerPrefs.GetInt(_isSound) == _trueValue)
            {
                _toggleSound.isOn = false;
            }
            else
            {
                _toggleSound.isOn = true;
            }
        }
    }

    private void Update()
    {
        if(_oldValueMusic != _sliderMusic.value)
        {
            PlayerPrefs.SetFloat(_valueMusic, _sliderMusic.value);
            PlayerPrefs.Save();
            _oldValueMusic = _sliderMusic.value;
            ChangeValueMusic?.Invoke();
        }
        
        if(_oldValueSound != _sliderSound.value)
        {
            PlayerPrefs.SetFloat(_valueSound, _sliderSound.value);
            PlayerPrefs.Save();
            _oldValueMusic = _sliderSound.value;
            ChangeValueSound?.Invoke();
        }

        if (_toggleMusic.isOn == false)
        {
            PlayerPrefs.SetInt(_isMusic, _trueValue);
            ChangeIsMusic?.Invoke();
        }
        else
        {
            PlayerPrefs.SetInt(_isMusic, _falseValue);
            ChangeIsMusic?.Invoke();
        }
        
        if (_toggleSound.isOn == false)
        {
            PlayerPrefs.SetInt(_isSound, _trueValue);
            ChangeIsSound?.Invoke();
        }
        else
        {
            PlayerPrefs.SetInt(_isSound, _falseValue);
            ChangeIsSound?.Invoke();
        }
    }
}
