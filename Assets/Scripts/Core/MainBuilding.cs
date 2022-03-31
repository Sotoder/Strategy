using Abstractions;
using UnityEngine;

public sealed class MainBuilding : MonoBehaviour, IAttackable, ISelectable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public bool IsEnemy => _isEnemy;

    [SerializeField] private bool _isEnemy;
    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;

    private float _health = 1000;
}