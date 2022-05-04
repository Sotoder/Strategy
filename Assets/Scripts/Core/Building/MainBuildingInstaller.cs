using Abstractions;
using Core.CommandExecutors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core
{ 
    public class MainBuildingInstaller : MonoInstaller
    {
        [SerializeField] private MainBuilding _mainBuilding;
        [SerializeField] private FactionMember _factionMember;
        [SerializeField] private UnitProducer _unitProducer;

        public override void InstallBindings()
        {
            Container.Bind<MainBuilding>().FromInstance(_mainBuilding);
            Container.Bind<FactionMember>().FromInstance(_factionMember);
            Container.BindInterfacesAndSelfTo<UnitProducer>().FromInstance(_unitProducer);
        }
    }
}
