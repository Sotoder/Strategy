using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Zenject;

namespace UserControlSystem.CommandsRealization
{
    public class ChomperHPUpgradeCommand : UnitUpgradeCommand, IChomperHPUpgradeCommand
    {
        [Inject(Id = "ChomperUpgrade")] public string UpgradeName { get; }
        [Inject(Id = "ChomperUpgrade")] public Sprite Icon { get; }
        [Inject(Id = "ChomperUpgrade")] public float ProductionTime { get; }

        public int UnitTypeID => _unitTypeID;

        public ChomperHPUpgradeCommand (int upgradableUnitTypeID): base(upgradableUnitTypeID)
        {

        }
    }
}