using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetterTextParametersWeapon : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private int _index;

    private void OnEnable()
    {
        float damage = ListOfCardsWeapon.GiveDamage(_index);
        float cooldown = ListOfCardsWeapon.GiveCooldown(_index);

        _text.text = $"Damage - {damage}" +
            $"\nCooldown - {cooldown}";
    }
}
