using Abstractions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = nameof(UpgradesComposite), menuName = nameof(UpgradesComposite), order = 11)]
    public class UpgradesComposite : ScriptableObject
    {
        private Dictionary<int, List<IUpgradeModel>> _upgradesCollection = new Dictionary<int, List<IUpgradeModel>>();

        public Dictionary<int, List<IUpgradeModel>> UpgradesCollection => _upgradesCollection;

        public bool IsUnitHaveAnyUpgrade(IUpgradableUnit unit)
        {
            if (_upgradesCollection.ContainsKey(unit.FactionID))
            {
                var upgradesList = _upgradesCollection[unit.FactionID];

                var anyUpgrade = upgradesList.Find(upgrade => unit.UnitTypeID == upgrade.UnitTypeID);

                if (anyUpgrade != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}