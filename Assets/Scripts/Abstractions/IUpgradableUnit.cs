
namespace Abstractions
{
    public interface IUpgradableUnit : IHealthHolder
    {
        int UnitTypeID {get; }
        int FactionID { get; }
        void UpgradeHealth(int amount);
    }
}
