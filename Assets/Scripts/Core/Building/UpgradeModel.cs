using Abstractions;

namespace Core
{
    public class UpgradeModel: IUpgradeModel
    {
        private int _amount;
        private int _upgradeID;
        private int _unitTypeID;

        public int UpgradeLevel { get; private set; }
        public int Amount => _amount;
        public int UpgradeID => _upgradeID;
        public int UnitTypeID => _unitTypeID;

        public UpgradeModel(int amount, int upgradeID, int unitTypeID, int upgradeCounts)
        {
            _amount = amount;
            _upgradeID = upgradeID;
            _unitTypeID = unitTypeID;
            UpgradeLevel = upgradeCounts;
        }

        public void ApplyUpgrade(IUpgradableUnit protoUnit)
        {
            var healthUpgrade = _amount * UpgradeLevel;
            protoUnit.UpgradeHealth(healthUpgrade);
        }

        public void IncreaseUpgradeLevel()
        {
            UpgradeLevel++;
        }
    }
}