using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using System.Threading.Tasks;
using Zenject;

public class ResetRallyPointCommandExecutor : CommandExecutorBase<IResetRallyPointCommand>
{
    [Inject] private MainBuilding _mainBuilding;
    public override Task ExecuteSpecificCommand(IResetRallyPointCommand command)
    {
        _mainBuilding.ResetRallyPoint();
        return Task.CompletedTask;
    }
}