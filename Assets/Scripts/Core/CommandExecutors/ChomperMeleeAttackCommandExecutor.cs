using Abstractions.Commands.CommandsInterfaces;
using Assets.Scripts.Abstractions;
using System;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Core.CommandExecutors
{
    public class ChomperMeleeAttackCommandExecutor : AttackCommandExecutor
    {
        private bool _isTargetAttacked;
        IDisposable _disposableFlow;

        protected override void DealDamageToTarget(IAttackable target)
        {
            _isTargetAttacked = false;

            var updateFilter = Observable.EveryUpdate().Where(_ => _animator != null)
                .Where(_ => _animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !_isTargetAttacked);

            _disposableFlow = updateFilter.Subscribe(_ =>
            {
                var animatorInfo = _animator.GetCurrentAnimatorStateInfo(0);
                if (animatorInfo.normalizedTime > 0.5f && animatorInfo.normalizedTime < 0.55f)
                {
                    target.ReceiveDamage(GetComponent<IDamageDealer>().Damage);
                    _isTargetAttacked = true;
                    _disposableFlow.Dispose();
                }
            }).AddTo(this);
        }

        public override async Task ExecuteSpecificCommand(IAttackCommand command)
        {
            await base.ExecuteSpecificCommand(command);
            _isTargetAttacked = false;
            _disposableFlow?.Dispose();
        }
    }
}