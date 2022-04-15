using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Zenject;

public class SetDistanationCommandExecutor : CommandExecutorBase<ISetDistanationCommand>
{
    [Inject] private MainBuilding _mainBuilding;
    public override void ExecuteSpecificCommand(ISetDistanationCommand command)
    {
        Debug.Log($"Set distanation to {command.Target}");
        _mainBuilding.UnitRallyPoint = command.Target;
    }
}