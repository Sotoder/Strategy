
namespace Abstractions
{
    public interface IUpgradeModel
    {
        void AplyUpgrade(IUpgradableUnit unit);
        int UpgradeCounts { get; set; }
        int Amount { get; }
        int UpgradeID { get; }
        int UnitTypeID { get; }
    }
}