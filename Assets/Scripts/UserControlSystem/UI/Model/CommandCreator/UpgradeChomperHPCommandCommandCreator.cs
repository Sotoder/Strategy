using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;
using Utils;
using Zenject;

namespace UserControlSystem
{
    public class UpgradeChomperHPCommandCommandCreator : CommandCreatorBase<IChomperUpgradeCommand>
    {
        [Inject] private DiContainer _diContainer;

        private int _chomperID = (int)UnitTypes.Chomper;
        protected override void ClassSpecificCommandCreation(Action<IChomperUpgradeCommand> creationCallback)
        {
            var upgradeUnitCommand = new ChomperHPUpgradeCommand(_chomperID);
            _diContainer.Inject(upgradeUnitCommand);
            creationCallback?.Invoke(upgradeUnitCommand);
        }
    }
}