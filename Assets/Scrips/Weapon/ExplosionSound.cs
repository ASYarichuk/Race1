using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSound : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    [SerializeField] private float _timeLifeSound = 2f;

    private readonly string _valueSound = "ValueSound";

    private readonly string _isSound = "IsSound";

    private readonly int _falseValue = 0;

    public void Play()
    {
        gameObject.transform.SetParent(null);
        _sound.volume = PlayerPrefs.GetFloat(_valueSound);

        if (PlayerPrefs.GetInt(_isSound) == _falseValue)
        {
            _sound.Play();
        }

        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_timeLifeSound);

        Destroy(gameObject);
    }
}
