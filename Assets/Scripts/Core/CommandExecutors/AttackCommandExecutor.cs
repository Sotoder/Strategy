using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using System.Threading.Tasks;
using UnityEngine;

public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
{
    public override Task ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log($"{name} is attacking to {command.Target}!");
        return Task.CompletedTask;
    }
}