using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _timeLifeBurst = 2f;

    public void Play()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
        gameObject.transform.SetParent(null);
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_timeLifeBurst);

        Destroy(gameObject);
    }
}