using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

public class HoldCommandExecutor : CommandExecutorBase<IStopCommand>
{
    public override void ExecuteSpecificCommand(IStopCommand command)
    {
        Debug.Log("Unit stop");
    }
}
