using Abstractions;
using Zenject;
using UnityEngine;

namespace Core
{
    public class GrinaderInstaller : MonoInstaller
    {
        [SerializeField] private FactionMember _factionMember;
        public override void InstallBindings()
        {
            Container.Bind<IHealthHolder>().FromComponentInChildren();
            Container.Bind<float>().WithId("AttackDistance").FromInstance(10f);
            Container.Bind<int>().WithId("AttackPeriod").FromInstance(1500);
            Container.Bind<FactionMember>().FromInstance(_factionMember);
        }
    }
}