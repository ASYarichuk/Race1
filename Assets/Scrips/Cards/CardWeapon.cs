using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardWeapon : Card
{
    private readonly float _cooldown;
    private float _damage;
    private bool _isOpen;

    public CardWeapon(float damage, float cooldown, int countStar, bool isIncreaseMaxLevel, bool isOpen)
    {
        _damage = damage;
        _cooldown = cooldown;
        SetMaxLevel(countStar);
        SetIncreaseMaxLevel(isIncreaseMaxLevel);
        _isOpen = isOpen;
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }

    public float GiveCooldown()
    {
        return _cooldown;
    }

    public float GiveDamage()
    {
        return _damage;
    }

    public bool GiveStateOpen()
    {
        return _isOpen;
    }

    public void ChangeStateOpen()
    {
        _isOpen = true;
    }
}
