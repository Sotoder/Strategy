using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem.CommandsRealization
{
    public class GrinaderHPUpgradeCommand : UnitUpgradeCommand, IGrinaderHPUpgradeCommand
    {
        public int UnitTypeID => _unitTypeID;

        public GrinaderHPUpgradeCommand(int upgradableUnitTypeID) : base(upgradableUnitTypeID)
        {

        }
    }
}