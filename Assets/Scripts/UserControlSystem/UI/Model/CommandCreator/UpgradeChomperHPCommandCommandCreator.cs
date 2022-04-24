using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;

namespace UserControlSystem
{
    public class UpgradeChomperHPCommandCommandCreator : CommandCreatorBase<IChomperHPUpgradeCommand>
    {
        private const int CHOMPER_ID = 252;
        protected override void ClassSpecificCommandCreation(Action<IChomperHPUpgradeCommand> creationCallback)
            => creationCallback?.Invoke(new ChomperHPUpgradeCommand(CHOMPER_ID));
    }
}