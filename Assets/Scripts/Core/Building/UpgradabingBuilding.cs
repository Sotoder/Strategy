using Abstractions;
using UnityEngine;
using Zenject;

namespace Core
{
    public class UpgradabingBuilding : MonoBehaviour, ISelectable, IAttackable
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform PivotPoint => _pivotPoint;
        public Sprite Icon => _icon;
        public int FactionID => _factionMember.FactionId;

        [Inject] private FactionMember _factionMember;

        [SerializeField] private float _maxHealth = 500;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;

        private float _health;

        private void Awake()
        {
            _health = _maxHealth;
        }

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

        private async void Destroy()
        {
            Destroy(gameObject);
        }
    }
}