using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using Zenject;

public class ResetRallyPointCommandExecutor : CommandExecutorBase<IResetRallyPointCommand>
{
    [Inject] private MainBuilding _mainBuilding;
    public override void ExecuteSpecificCommand(IResetRallyPointCommand command)
    {
        _mainBuilding.ResetRallyPoint();
    }
}