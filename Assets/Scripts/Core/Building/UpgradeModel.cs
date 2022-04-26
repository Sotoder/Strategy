using Abstractions;

namespace Core
{
    public class UpgradeModel: IUpgradeModel
    {
        private int _amount;
        private int _upgradeID;
        private int _unitTypeID;

        public int UpgradeCounts { get; set; }
        public int Amount => _amount;
        public int UpgradeID => _upgradeID;
        public int UnitTypeID => _unitTypeID;

        public UpgradeModel(int amount, int upgradeID, int unitTypeID, int upgradeCounts)
        {
            _amount = amount;
            _upgradeID = upgradeID;
            _unitTypeID = unitTypeID;
            UpgradeCounts = upgradeCounts;
        }

        public void AplyUpgrade(IUpgradableUnit protoUnit)
        {
            var healthUpgrade = _amount * UpgradeCounts;
            protoUnit.UpgradeHealth(healthUpgrade);
        }
    }
}