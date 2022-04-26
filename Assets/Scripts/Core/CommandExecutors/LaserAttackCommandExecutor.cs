using Abstractions.Commands.CommandsInterfaces;
using Assets.Scripts.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Core.CommandExecutors
{
    public class LaserAttackCommandExecutor : AttackCommandExecutor
    {
        [SerializeField] private ParticleSystem _innerBeam;
        [SerializeField] private ParticleSystem _outerBeam;

        private bool _isTargetAttacked;
        IDisposable _disposableFlow;

        protected override void DealDamageToTarget(IAttackable target)
        {
            _isTargetAttacked = false;
            _outerBeam.Play();
            _innerBeam.Play();

            _disposableFlow = Observable.EveryUpdate().Where(_ => _innerBeam != null)
                .Where(_ => _innerBeam.isPlaying && !_isTargetAttacked)
                .Subscribe(_ =>
                {
                    if (_innerBeam.time > _innerBeam.main.duration * 0.3)
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
            _outerBeam.Stop();
            _innerBeam.Stop();
            _isTargetAttacked = false;
            _disposableFlow?.Dispose();
        }
    }
}