using Abstractions.Commands.CommandsInterfaces;
using Assets.Scripts.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Core.CommandExecutors
{
    public class LaserAttackCommandExecutor : AttackCommandExecutor
    {
        [SerializeField] private ParticleSystem _innerBeam;
        [SerializeField] private ParticleSystem _outerBeam;

        protected override void StartAttackingTargets(IAttackable target)
        {
            {
                base.StartAttackingTargets(target);
                _outerBeam.Play();
                _innerBeam.Play();
            }
        }

        public override async Task ExecuteSpecificCommand(IAttackCommand command)
        {
            await base.ExecuteSpecificCommand(command);
            _outerBeam.Stop();
            _innerBeam.Stop();
        }
    }
}