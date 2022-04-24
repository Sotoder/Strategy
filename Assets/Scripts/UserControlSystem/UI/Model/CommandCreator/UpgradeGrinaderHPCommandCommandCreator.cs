using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;

namespace UserControlSystem
{
    public class UpgradeGrinaderHPCommandCommandCreator : CommandCreatorBase<IGrinaderHPUpgradeCommand>
    {
        private const int GRINADER_ID = 323;
        protected override void ClassSpecificCommandCreation(Action<IGrinaderHPUpgradeCommand> creationCallback)
            => creationCallback?.Invoke(new GrinaderHPUpgradeCommand(GRINADER_ID));
    }
}