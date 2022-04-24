
namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IChomperHPUpgradeCommand : ICommand
    {
        int UnitTypeID { get; }
    }
}