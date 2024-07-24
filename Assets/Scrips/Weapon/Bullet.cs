using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Ammunition
{
    [SerializeField] private AudioSource _launcherSound;

    private readonly string _valueSound = "ValueSound";

    private readonly string _isSound = "IsSound";

    private readonly int _falseValue = 0;

    private void Start()
    {
        _launcherSound.volume = PlayerPrefs.GetFloat(_valueSound);

        if (PlayerPrefs.GetInt(_isSound) == _falseValue)
        {
            _launcherSound.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
