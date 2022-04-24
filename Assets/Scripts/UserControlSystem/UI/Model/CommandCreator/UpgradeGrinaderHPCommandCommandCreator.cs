using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;
using Utils;
using Zenject;

namespace UserControlSystem
{
    public class UpgradeGrinaderHPCommandCommandCreator : CommandCreatorBase<IGrinaderHPUpgradeCommand>
    {
        [Inject] private DiContainer _diContainer;

        private int _grinaderID = (int)UnitTypes.Grinader;
        protected override void ClassSpecificCommandCreation(Action<IGrinaderHPUpgradeCommand> creationCallback)
        {
            var upgradeUnitCommand = new GrinaderHPUpgradeCommand(_grinaderID);
            _diContainer.Inject(upgradeUnitCommand);
            creationCallback?.Invoke(upgradeUnitCommand);
        }
    }
}