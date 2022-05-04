
namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IUnitUpgradeCommand : ICommand, IIconHolder
    {
        int UnitTypeID { get; }
        float ProductionTime { get; }
        string UpgradeName { get; }
    }
}