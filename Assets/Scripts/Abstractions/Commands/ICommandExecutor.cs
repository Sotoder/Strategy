using UnityEngine;

namespace Abstractions.Commands
{
    public interface ICommandExecutor
    {
        void ExecuteCommand(object command);
        Transform transform { get; }
    }
}