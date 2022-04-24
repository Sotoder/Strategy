
namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IGrinaderHPUpgradeCommand : ICommand, IIconHolder
    {
        int UnitTypeID { get; }
        float ProductionTime { get; }
        string UpgradeName { get; }
    }
}
