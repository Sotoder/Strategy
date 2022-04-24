using Abstractions.Commands.CommandsInterfaces;
using Abstractions.Executors;
using UnityEngine;
using Zenject;

public class UpgradeBuildingCommandQueue : MonoBehaviour, ICommandsQueue
{
    [Inject] private CommandExecutorBase<IChomperUpgradeCommand> _chomperHPUpgradeCommandExecutor;
    [Inject] private CommandExecutorBase<IGrinaderUpgradeCommand> _grinaderHPUpgradeCommandExecutor;
    public void Clear() { }
    public async void EnqueueCommand(object command)
    {
        await _chomperHPUpgradeCommandExecutor.TryExecuteCommand(command);
        await _grinaderHPUpgradeCommandExecutor.TryExecuteCommand(command);
    }
}
