using Abstractions;
using UnityEngine;

public class Enemy : MonoBehaviour, IAttackable, IUnit
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;

    [SerializeField] private float _maxHealth = 100;

    private float _health = 100;
}
