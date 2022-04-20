using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Core.CommandExecutors
{
    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private HoldCommandExecutor _holdCommandExecutor;

        private Vector3[] _patrolPoints = new Vector3[2];
        private int _curentPatrolPointIndex;

        private readonly int Walk = Animator.StringToHash("Walk");
        private readonly int Idle = Animator.StringToHash("Idle");

        public override async Task ExecuteSpecificCommand(IPatrolCommand command)
        {
            _holdCommandExecutor.Cts = new CancellationTokenSource();
            _patrolPoints[0] = command.From;
            _patrolPoints[1] = command.To;

            _animator.SetTrigger(Walk);

            while (true)
            {
                _curentPatrolPointIndex = (_curentPatrolPointIndex + 1) % _patrolPoints.Length;
                _agent.destination = _patrolPoints[_curentPatrolPointIndex];

                try
                {
                    await _stop.WithCancellation(_holdCommandExecutor.Cts.Token);
                }
                catch
                {
                    _agent.ResetPath();
                    break;
                }
            }

            _holdCommandExecutor.Cts = null;
            _animator.SetTrigger(Idle);
        }
    }
}