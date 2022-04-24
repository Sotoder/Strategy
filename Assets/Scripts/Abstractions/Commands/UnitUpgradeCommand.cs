using Abstractions.Commands.CommandsInterfaces;


namespace Abstractions.Commands
{
    public abstract class UnitUpgradeCommand
    {
        protected int _unitTypeID;

        protected UnitUpgradeCommand (int upgradableUnitTypeID)
        {
            _unitTypeID = upgradableUnitTypeID;
        }
    }
}