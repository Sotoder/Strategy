using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
{
    public override void ExecuteSpecificCommand(IPatrolCommand command)
    {
        for(int i = 1; i <= command.PatrolPoints.Count; i++)
        {
            Debug.Log($"Patrol point {i} = {command.PatrolPoints[i-1]}");
        }
    }
}
