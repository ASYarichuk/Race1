using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardWeapon : Card
{
    private readonly float _cooldown;
    private float _damage;

    public CardWeapon(float damage, float cooldown, int countStar, bool isIncreaseMaxLevel)
    {
        _damage = damage;
        _cooldown = cooldown;
        SetMaxLevel(countStar);
        SetIncreaseMaxLevel(isIncreaseMaxLevel);
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
}
