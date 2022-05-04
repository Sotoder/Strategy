using Abstractions;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class HPInprover : MonoBehaviour
    {
        [SerializeField] private MainUnit _unit;
        [SerializeField] private UpgradableUnitsComposite _upgradableUnitsComposit;

        public int UnitTypeID => _unit.UnitTypeID;

        private void Start()
        {
            Register();
        }

        private void Register()
        {
            lock (_upgradableUnitsComposit.UpgradableUnitsCollection)
            {
                if (!_upgradableUnitsComposit.UpgradableUnitsCollection.ContainsKey(_unit.FactionID))
                {
                    _upgradableUnitsComposit.UpgradableUnitsCollection.Add(_unit.FactionID, new List<HPInprover>());
                }
                if (!_upgradableUnitsComposit.UpgradableUnitsCollection[_unit.FactionID].Contains(this))
                {
                    _upgradableUnitsComposit.UpgradableUnitsCollection[_unit.FactionID].Add(this);
                }
            }
        }
        private void Unregister()
        {
            lock (_upgradableUnitsComposit.UpgradableUnitsCollection)
            {
                if (_upgradableUnitsComposit.UpgradableUnitsCollection[_unit.FactionID].Contains(this))
                {
                    _upgradableUnitsComposit.UpgradableUnitsCollection[_unit.FactionID].Remove(this);
                }
                if (_upgradableUnitsComposit.UpgradableUnitsCollection[_unit.FactionID].Count == 0)
                {
                    _upgradableUnitsComposit.UpgradableUnitsCollection.Remove(_unit.FactionID);
                }
            }
        }

        private void OnDestroy()
        {
            Unregister();
        }

        public void ImproveCommand(int amount)
        {
            _unit.UpgradeHealth(amount);
        }
    }
}