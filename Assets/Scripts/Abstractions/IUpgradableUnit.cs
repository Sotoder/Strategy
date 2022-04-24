
namespace Abstractions
{
    public interface IUpgradableUnit : IHealthHolder
    {
        void UpgradeHealth(int amount);
    }
}
