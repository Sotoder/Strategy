using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using Abstractions.Executors;
using System.Threading;
using System.Threading.Tasks;

namespace Core
{
    public class HoldCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        public CancellationTokenSource Cts { get; set; }
        public override Task ExecuteSpecificCommand(IStopCommand command)
        {
            Cts?.Cancel();
            return Task.CompletedTask;
        }
    }
}