using Zenject;
using UnityEngine;

namespace Core
{
    public class CoreInstaller : MonoInstaller
    {
        [SerializeField] private UpgradesComposite _upgradesComposite;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TimeModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<UpgradesComposite>().FromInstance(_upgradesComposite);
        }
    }
}