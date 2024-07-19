using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Ammunition
{
    [SerializeField] private AudioSource _launcherSound;

    private void Start()
    {
        _launcherSound.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
