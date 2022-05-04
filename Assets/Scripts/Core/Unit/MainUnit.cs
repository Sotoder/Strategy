using Abstractions;
using Assets.Scripts.Abstractions;
using Core.CommandExecutors;
using UnityEngine;
using Utils;
using Zenject;

namespace Core
{
    public class MainUnit : MonoBehaviour, ISelectable, IAttackable, IUnit, IDamageDealer, IUpgradableUnit
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform PivotPoint => _pivotPoint;
        public Sprite Icon => _icon;
        public int Damage => _damage;
        public int FactionID => _factionMember.FactionId;
        public int UnitTypeID => (int)_unitType;

        [Inject] protected FactionMember _factionMember;

        [SerializeField] protected UnitTypes _unitType;
        [SerializeField] protected Animator _animator;
        [SerializeField] protected HoldCommandExecutor _stopCommand;
        [SerializeField] protected float _maxHealth = 100;
        [SerializeField] protected Sprite _icon;
        [SerializeField] protected Transform _pivotPoint;
        [SerializeField] protected int _damage = 25;
        protected float _health;

        protected void Start()
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
                _animator.SetTrigger("PlayDead");
                Invoke(nameof(Destroy), 1f);
            }
        }

        protected async void Destroy()
        {
            await _stopCommand.ExecuteSpecificCommand(new StopCommand());
            Destroy(gameObject);
        }

        public void UpgradeHealth(int amount)
        {
            _maxHealth += amount;
            _health += amount;
        }
    }
}