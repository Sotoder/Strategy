
namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IGrinaderHPUpgradeCommand : ICommand
    {
        int UnitTypeID { get; }
    }
}
