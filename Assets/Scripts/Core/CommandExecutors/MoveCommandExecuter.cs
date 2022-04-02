using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using Core;
using UnityEngine;
using UnityEngine.AI;

public class MoveCommandExecuter : CommandExecutorBase<IMoveCommand>
{
    [SerializeField] private UnitMovementStop _stop;
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _navAgent;
    [SerializeField] private NavMeshObstacle _obstacle;

    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int Idle = Animator.StringToHash("Idle");

    public override async void ExecuteSpecificCommand(IMoveCommand command)
    {
        _obstacle.enabled = false;
        _navAgent.enabled = true;
        _navAgent.destination = command.Target;
        _animator.SetTrigger(Walk);
        await _stop;
        _animator.SetTrigger(Idle);
    }
}