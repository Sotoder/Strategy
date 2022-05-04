using Abstractions.Commands.CommandsInterfaces;
using Abstractions.Executors;
using UnityEngine;
using Zenject;

namespace Core
{
    public class MainBuildingCommandQueue : MonoBehaviour, ICommandsQueue
    {
        [Inject] private CommandExecutorBase<IProduceChomperCommand> _produceChomperCommandExecutor;
        [Inject] private CommandExecutorBase<IProduceGrinaderCommand> _produceGrinaderCommandExecutor;
        [Inject] private CommandExecutorBase<ISetDistanationCommand> _setDistanationExecutor;
        public void Clear() { }
        public async void EnqueueCommand(object command)
        {
            await _produceChomperCommandExecutor.TryExecuteCommand(command);
            await _setDistanationExecutor.TryExecuteCommand(command);
            await _produceGrinaderCommandExecutor.TryExecuteCommand(command);
        }
    }
}