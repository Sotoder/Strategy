using Abstractions;
using UnityEngine;

public class Enemy : MonoBehaviour, IAttackable, IUnit
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;

    [SerializeField] private float _maxHealth = 100;

    private float _health = 100;
    public void ReceiveDamage(int amount)
    {
        if (_health <= 0)
        {
            return;
        }
        _health -= amount;
        if (_health <= 0)
        {
            Invoke(nameof(Destroy), 1f);
        }
    }

}
