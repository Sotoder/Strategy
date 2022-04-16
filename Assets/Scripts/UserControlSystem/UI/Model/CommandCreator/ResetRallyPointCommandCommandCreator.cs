using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;

namespace UserControlSystem
{
    public sealed class ResetRallyPontCommandCommandCreator : CommandCreatorBase<IResetRallyPointCommand>
    {
        protected override void ClassSpecificCommandCreation(Action<IResetRallyPointCommand> creationCallback)
            => creationCallback?.Invoke(new ResetRallyPointCommand());
    }
}