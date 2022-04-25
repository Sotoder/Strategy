using Abstractions.Commands.CommandsInterfaces;
using Assets.Scripts.Abstractions;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Core.CommandExecutors
{
    public class ChomperMeleeAttackCommandExecutor : AttackCommandExecutor
    {
        private bool _isTargetAttacked;

        protected override void DealDamageToTarget(IAttackable target)
        {
            _isTargetAttacked = false;

            var updateFilter = Observable.EveryUpdate().Where(_ => _animator != null)
                .Where(_ => _animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !_isTargetAttacked);

            updateFilter.Select(_ => target).Subscribe(target =>
            {
                var animatorInfo = _animator.GetCurrentAnimatorStateInfo(0);
                if (animatorInfo.normalizedTime > 0.5f && animatorInfo.normalizedTime < 0.55f)
                {
                    target.ReceiveDamage(GetComponent<IDamageDealer>().Damage);
                    _isTargetAttacked = true;
                }
            });
        }

        public override async Task ExecuteSpecificCommand(IAttackCommand command)
        {
            await base.ExecuteSpecificCommand(command);
            _isTargetAttacked = false;
        }
    }
}