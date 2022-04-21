using Abstractions.Commands.CommandsInterfaces;
using Abstractions.Executors;
using UnityEngine;
using Zenject;

namespace Core
{
    public class MainBuildingCommandQueue : MonoBehaviour, ICommandsQueue
    {
        [Inject] private CommandExecutorBase<IProduceUnitCommand> _produceUnitCommandExecutor;
        [Inject] private CommandExecutorBase<ISetDistanationCommand> _setDistanationExecutor;
        public void Clear() { }
        public async void EnqueueCommand(object command)
        {
            await _produceUnitCommandExecutor.TryExecuteCommand(command);
            await _setDistanationExecutor.TryExecuteCommand(command);
        }
    }
}