using Abstractions;
using UnityEngine;
using Utils;

public sealed class MainBuilding : MonoBehaviour, ISelectable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Outline ObjectOutline => _outline;

    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;

    private float _health = 1000;
    private Outline _outline;

    private void Start()
    {
        _outline = gameObject.GetComponent<Outline>();
    }
}