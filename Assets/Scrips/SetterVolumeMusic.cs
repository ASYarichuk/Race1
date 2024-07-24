using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetterVolumeMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _music;

    private readonly string _valueMusic = "ValueMusic";

    private readonly string _isMusic = "IsMusic";

    private readonly int _trueValue = 1;

    private void Awake()
    {
        ChangeMusic();
        ChangeIsMusic();
    }

    private void OnEnable()
    {
        ControllerMusicSound.ChangeValueMusic += ChangeMusic;
        ControllerMusicSound.ChangeIsMusic += ChangeIsMusic;
    }

    private void OnDisable()
    {
        ControllerMusicSound.ChangeValueMusic -= ChangeMusic;
        ControllerMusicSound.ChangeIsMusic -= ChangeIsMusic;
    }

    private void ChangeMusic()
    {
        _music.volume = PlayerPrefs.GetFloat(_valueMusic);
    }

    private void ChangeIsMusic()
    {
        if (PlayerPrefs.GetInt(_isMusic) == _trueValue)
        {
            _music.mute = true;
        }
        else
        {
            _music.mute = false;
        }
    }
}
