using Abstractions;
using UnityEngine;
using Zenject;

namespace Core
{
    public sealed class MainBuilding : MonoBehaviour, ISelectable, IAttackable
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform PivotPoint => _pivotPoint;
        public Sprite Icon => _icon;
        public int FactionID => _factionMember.FactionId;

        [Inject] private FactionMember _factionMember;

        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;

        private float _health = 1000;

        public Vector3 UnitRallyPoint;

        private Vector3 _baseRallyPoint;

        private void Start()
        {
            _baseRallyPoint = new Vector3(this.transform.position.x - 3, 0, this.transform.position.z);
            UnitRallyPoint = _baseRallyPoint;
        }

        public void ResetRallyPoint()
        {
            UnitRallyPoint = _baseRallyPoint;
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