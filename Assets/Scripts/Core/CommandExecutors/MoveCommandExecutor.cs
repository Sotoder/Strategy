using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
{
    public override void ExecuteSpecificCommand(IMoveCommand command)
    {
        Debug.Log("Unit move");
    }
}
