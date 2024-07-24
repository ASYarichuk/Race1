using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetterVolumeSound : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

    private readonly string _valueSound = "ValueSound";

    private readonly string _isSound = "IsSound";

    private readonly int _trueValue = 1;

    private void Start()
    {
        ChangeSound();
        ChangeIsSound();
    }

    private void OnEnable()
    {
        ControllerMusicSound.ChangeValueSound += ChangeSound;
        ControllerMusicSound.ChangeIsSound += ChangeIsSound;
    }
    
    private void OnDisable()
    {
        ControllerMusicSound.ChangeValueSound -= ChangeSound;
        ControllerMusicSound.ChangeIsSound -= ChangeIsSound;
    }

    private void ChangeSound()
    {
         _sound.volume = PlayerPrefs.GetFloat(_valueSound);
    } 
    
    private void ChangeIsSound()
    {
        if (PlayerPrefs.GetInt(_isSound) == _trueValue)
        {
            _sound.mute = true;
        }
        else
        {
            _sound.mute = false;
        }      
    }
}
