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

        public override void InstallBindings()
        {
            Container.Bind<MainBuilding>().FromInstance(_mainBuilding);
        }
    }
}
