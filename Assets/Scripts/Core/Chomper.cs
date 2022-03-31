using Abstractions;
using UnityEngine;

public class Chomper : BaseUnit, IAttackable
{
    public float Health => _health;
    public bool IsEnemy => _isEnemy;

    [SerializeField] private bool _isEnemy;

    private float _health = 100;
}
