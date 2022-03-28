using Abstractions.Commands;
using System.Collections.Generic;
using UnityEngine;
using Utils;

[CreateAssetMenu(fileName = "CommandExecutorsList", menuName = "Strategy Game/" + nameof(CommandExecutorsListConfig), order = 0)]
public class CommandExecutorsListConfig : ScriptableObject
{
    [SerializeField] private bool _isProduceUnit;
    [SerializeField] private bool _isMove;
    [SerializeField] private bool _isAttack;
    [SerializeField] private bool _isPatrol;
    [SerializeField] private bool _isStop;
    [SerializeField] private AssetsContext _context;

    private List<ICommandExecutor> _commandExecutorsList = new List<ICommandExecutor>();

    public List<ICommandExecutor> GetCommandExecutorsList()
    {
        if (_isProduceUnit)
        {
            var produceExecutor = _context.Inject(new ProduceUnitCommandExecutor());
            _commandExecutorsList.Add(produceExecutor);
        }

        if (_isMove)
        {
            var moveExecutor = _context.Inject(new MoveCommandExecutor());
            _commandExecutorsList.Add(moveExecutor);
        }

        if (_isAttack)
        {
            var attackExecutor = _context.Inject(new AttackCommandExecutor());
            _commandExecutorsList.Add(attackExecutor);
        }

        if (_isPatrol)
        {
            var patrolExecutor = _context.Inject(new PatrolCommandExecutor());
            _commandExecutorsList.Add(patrolExecutor);
        }

        if (_isStop)
        {
            var holdExecutor = _context.Inject(new HoldCommandExecutor());
            _commandExecutorsList.Add(holdExecutor);
        }


        return _commandExecutorsList;
    }
}