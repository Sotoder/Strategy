using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
{
    public override void ExecuteSpecificCommand(IAttackCommand command)
    {
        if (command.Enemy is null)
        {
            Debug.Log($"{name} is attacking to {command.Target}!");
        } else
        {
            Debug.Log($"{name} is attacking {command.Enemy.name}!");
        }       
    }        
}
