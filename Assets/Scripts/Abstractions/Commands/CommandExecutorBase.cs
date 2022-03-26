using UnityEngine;

namespace Abstractions.Commands
{
    public abstract class CommandExecutorBase<T> : ICommandExecutor where T : ICommand
    {
        public void ExecuteCommand(object command) => ExecuteSpecificCommand((T)command);

        public abstract void ExecuteSpecificCommand(T command);
    }
}