using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using Abstractions.Executors;
using System.Threading.Tasks;
using Zenject;

namespace Core.CommandExecutors
{
    public class ResetRallyPointCommandExecutor : CommandExecutorBase<IResetRallyPointCommand>
    {
        [Inject] private MainBuilding _mainBuilding;
        public override Task ExecuteSpecificCommand(IResetRallyPointCommand command)
        {
            _mainBuilding.ResetRallyPoint();
            return Task.CompletedTask;
        }
    }
}