using Abstractions;
using UnityEngine;

public class Gunner : BaseUnit, IAttackable, ISelectable
{
    public float Health => _health;

    private float _health = 100;
}
