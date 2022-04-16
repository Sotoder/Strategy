﻿using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using System.Threading.Tasks;
using UnityEngine;

public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
{
    public override Task ExecuteSpecificCommand(IPatrolCommand command)
    {
        Debug.Log($"Patrol from {command.From} to {command.To}");
        return Task.CompletedTask;
    }
}