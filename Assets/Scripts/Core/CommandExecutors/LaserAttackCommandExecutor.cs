using Abstractions.Commands.CommandsInterfaces;
using Assets.Scripts.Abstractions;
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

        protected override void DealDamageToTarget(IAttackable target)
        {
            _isTargetAttacked = false;
            _outerBeam.Play();
            _innerBeam.Play();

            Observable.EveryUpdate().Where(_ => _innerBeam != null)
                .Where(_ => _innerBeam.isPlaying && !_isTargetAttacked).Select(_ => target)
                .Subscribe(target =>
                {
                    if (_innerBeam.time > _innerBeam.main.duration * 0.3)
                    {
                        target.ReceiveDamage(GetComponent<IDamageDealer>().Damage);
                        _isTargetAttacked = true;
                    }
                });
        }


        public override async Task ExecuteSpecificCommand(IAttackCommand command)
        {
            await base.ExecuteSpecificCommand(command);
            _outerBeam.Stop();
            _innerBeam.Stop();
            _isTargetAttacked = false;
        }
    }
}