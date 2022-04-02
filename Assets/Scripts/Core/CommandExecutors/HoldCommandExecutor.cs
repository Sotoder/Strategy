using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using System.Threading;

public class HoldCommandExecutor : CommandExecutorBase<IStopCommand>
{
    public CancellationTokenSource Cts { get; set; }
    public override void ExecuteSpecificCommand(IStopCommand command)
    {
        Cts?.Cancel();
    }
}
