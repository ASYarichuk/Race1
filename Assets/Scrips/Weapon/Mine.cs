using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Ammunition
{
    [SerializeField] private float _radiusBurst;
    [SerializeField] private GameObject _body;
    [SerializeField] private ExplosionSound _exposionSound;
    [SerializeField] private Explosion _explosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMover>() || 
            other.gameObject.GetComponent<Ammunition>() || 
            other.gameObject.GetComponent<AIMover>())
        {
            Explosion();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMover>() ||
            collision.gameObject.GetComponent<Ammunition>() || 
            collision.gameObject.GetComponent<AIMover>())
        {
            Explosion();
        }
    }

    private void Explosion()
    {
        gameObject.GetComponent<SphereCollider>().radius = _radiusBurst;
        _explosion.Play();
        _exposionSound.Play();
        _body.SetActive(false);
        Destroy(gameObject);
    }
}
