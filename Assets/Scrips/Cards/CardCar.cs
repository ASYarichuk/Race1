using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCar : Card
{
    private float _health;
    private float _armor;
    private float _torque;
    private float _maxSpeed;
    private readonly float _maxArmor = 50;

    public CardCar(float health, float armor, float torque, float maxSpeed, bool isIncreaseMaxLevel)
    {
        _health = health;
        _armor = armor;
        _torque = torque;
        _maxSpeed = maxSpeed;
        SetIncreaseMaxLevel(isIncreaseMaxLevel);

        if (_armor > _maxArmor)
        {
            _armor = _maxArmor;
        }
    }

    public void SetParameters(float[] parameters)
    {
        _health = parameters[0];
        _armor = parameters[1];
        _torque = parameters[2];
        _maxSpeed = parameters[3];
    }

    public float[] GiveParameters()
    {
        float[] parameters = new float[4]
        {
            _health,
            _armor,
            _torque,
            _maxSpeed
        };

        return parameters;
    }
}
