
namespace Abstractions
{
    public interface IUpgradeModel
    {
        void ApplyUpgrade(IUpgradableUnit unit);
        void IncreaseUpgradeLevel();
        int UpgradeLevel { get; }
        int Amount { get; }
        int UpgradeID { get; }
        int UnitTypeID { get; }
    }
}