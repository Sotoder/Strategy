using Abstractions;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class Chomper : MonoBehaviour, ISelectable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Outline ObjectOutline => _outline;

    public Transform PivotPoint => _pivotPoint;

    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _pivotPoint;
    [SerializeField] private NavMeshAgent _navAgent;
    [SerializeField] private NavMeshObstacle _obstacle;

    private float _health = 100;
    private Outline _outline;

    private void Start()
    {
        _outline = gameObject.GetComponent<Outline>();
        _navAgent.enabled = false;
        _obstacle.enabled = true;
    }
}
