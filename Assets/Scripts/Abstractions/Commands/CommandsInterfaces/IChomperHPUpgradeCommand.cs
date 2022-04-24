
namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IChomperHPUpgradeCommand : ICommand, IIconHolder
    {
        int UnitTypeID { get; }
        float ProductionTime { get; }
        string UpgradeName { get; }
    }
}