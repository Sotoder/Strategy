using Abstractions;
using Core.CommandExecutors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core
{ 
    public class UpgradingBuildingInstaller : MonoInstaller
    {
        [SerializeField] private UpgradabingBuilding _upgradabingBuilding;
        [SerializeField] private FactionMember _factionMember;
        [SerializeField] private UpgradableUnitsComposit _upgradableUnitsComposit;

        public override void InstallBindings()
        {
            Container.Bind<UpgradabingBuilding>().FromInstance(_upgradabingBuilding);
            Container.Bind<FactionMember>().FromInstance(_factionMember);
            Container.Bind<UpgradableUnitsComposit>().FromInstance(_upgradableUnitsComposit);
        }
    }
}
