using Abstractions;
using Zenject;
using UnityEngine;

namespace Core
{
    public class ChomperInstaller : MonoInstaller
    {
        [SerializeField] private FactionMember _factionMember;
        public override void InstallBindings()
        {
            Container.Bind<IHealthHolder>().FromComponentInChildren();
            Container.Bind<float>().WithId("AttackDistance").FromInstance(5f);
            Container.Bind<int>().WithId("AttackPeriod").FromInstance(1400);
            Container.Bind<FactionMember>().FromInstance(_factionMember);
        }
    }
}