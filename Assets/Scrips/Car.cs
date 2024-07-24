using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _armor;
    [SerializeField] private bool _isPlayer = false;

    private float _damageMultiplier;
    private float _currentDamage;

    private void OnEnable()
    {
        if (gameObject.GetComponent<PlayerMover>())
        {
            _isPlayer = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ammunition ammunition))
        {
            if (other.TryGetComponent(out Mine mine) && _isPlayer == false)
            {
                TakeDamage(mine.GiveDamage() / 10);
            }
            else
            {
                TakeDamage(ammunition.GiveDamage());
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Ammunition ammunition))
        {
            TakeDamage(ammunition.GiveDamage());
        }
    }

    public void SetHealth(float health)
    {
        _health = health;
    }

    public void SetArmor(float armor)
    {
        _armor = armor;
    }

    public void TakeDamage(float damage)
    {
        _damageMultiplier = (100 - _armor) / 100;
        _currentDamage = damage * _damageMultiplier;

        _health -= _currentDamage;

        if (_health <= 0)
        {
            if (_isPlayer)
            {
                Time.timeScale = 0f;
                GetComponentInParent<LoseGame>().EnableWindow();
            }
            else
            {
                Death();
            }
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
