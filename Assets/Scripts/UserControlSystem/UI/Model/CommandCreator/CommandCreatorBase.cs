using System;
using Abstractions.Commands;

namespace UserControlSystem
{
    public abstract class CommandCreatorBase<T> where T : ICommand
    {
        protected ICommandExecutor _commandExecutor;
        public ICommandExecutor ProcessCommandExecutor(ICommandExecutor commandExecutor, Action<T> callback)
        {
            _commandExecutor = commandExecutor;
            var classSpecificExecutor = commandExecutor as CommandExecutorBase<T>;
            if (classSpecificExecutor != null)
            {
                ClassSpecificCommandCreation(callback);
            }
            return commandExecutor;
        }

        protected abstract void ClassSpecificCommandCreation(Action<T> creationCallback);

        public virtual void ProcessCancel() { }
    }
}