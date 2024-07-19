using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSound : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    [SerializeField] private float _timeLifeSound = 2f;

    public void Play()
    {
        gameObject.transform.SetParent(null);
        _sound.Play();
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_timeLifeSound);

        Destroy(gameObject);
    }
}
