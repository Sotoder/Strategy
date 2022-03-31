using Abstractions;
using UnityEngine;

public class Chomper : BaseUnit, IAttackable, ISelectable
{
    public float Health => _health;

    private float _health = 100;
}
