using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Ammunition
{
    [SerializeField] private float _radiusBurst;
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private float _timeLifeBurst = 1.5f;
    [SerializeField] private GameObject _body;
    [SerializeField] private ExplosionSound _exposionSound;
    [SerializeField] private AudioSource _launcherSound;

    private void Start()
    {
        _explosion = GetComponentInChildren<ParticleSystem>();
        _launcherSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explosion();
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_timeLifeBurst);

        Destroy(_explosion.gameObject);
        Destroy(gameObject);
    }

    private void Explosion()
    {
        gameObject.GetComponent<CapsuleCollider>().radius = _radiusBurst;
        _explosion.transform.SetParent(null);
        _explosion.Play();
        _exposionSound.Play();
        gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
        _body.SetActive(false);
        StartCoroutine(Destroy());
    }
}
