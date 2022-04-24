using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem.CommandsRealization
{
    public class ChomperHPUpgradeCommand : UnitUpgradeCommand, IChomperHPUpgradeCommand
    {
        public int UnitTypeID => _unitTypeID;

        public ChomperHPUpgradeCommand (int upgradableUnitTypeID): base(upgradableUnitTypeID)
        {

        }
    }
}