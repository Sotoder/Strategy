using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Zenject;

namespace UserControlSystem.CommandsRealization
{
    public class GrinaderHPUpgradeCommand : UnitUpgradeCommand, IGrinaderHPUpgradeCommand
    {
        [Inject(Id = "GrinaderUpgrade")] public string UpgradeName { get; }
        [Inject(Id = "GrinaderUpgrade")] public Sprite Icon { get; }
        [Inject(Id = "GrinaderUpgrade")] public float ProductionTime { get; }

        public int UnitTypeID => _unitTypeID;

        public GrinaderHPUpgradeCommand(int upgradableUnitTypeID) : base(upgradableUnitTypeID)
        {

        }
    }
}