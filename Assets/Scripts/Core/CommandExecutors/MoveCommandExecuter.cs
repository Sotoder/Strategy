using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using Core;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using Utils;
using Zenject;

public class MoveCommandExecuter : CommandExecutorBase<IMoveCommand>
{
    [SerializeField] private UnitMovementStop _stop;
    [SerializeField] private Animator _animator;

    [Inject] private NavMeshAgent _navAgent;
    [Inject] private NavMeshObstacle _obstacle;
    [Inject] private HoldCommandExecutor _holdCommandExecutor;

    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int Idle = Animator.StringToHash("Idle");

    public override async void ExecuteSpecificCommand(IMoveCommand command)
    {
        _holdCommandExecutor.Cts = new CancellationTokenSource();


        _obstacle.enabled = false;
        _navAgent.enabled = true;
        _navAgent.SetDestination(command.Target);
        _animator.SetTrigger(Walk);
        try
        {
            await _stop.WithCancellation(_holdCommandExecutor.Cts.Token);
        }
        catch
        {
            _navAgent.ResetPath();
        }
        _animator.SetTrigger(Idle);
    }
}