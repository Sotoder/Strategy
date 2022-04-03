using UnityEngine;
using UnityEngine.AI;
using Zenject;


public class ChomperModelInstaller : MonoInstaller
{
    [SerializeField] private HoldCommandExecutor _holdExecutor;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private NavMeshObstacle _obstacle;

    public override void InstallBindings()
    {
        Container.Bind<HoldCommandExecutor>().FromInstance(_holdExecutor);
        Container.Bind<NavMeshAgent>().FromInstance(_agent);
        Container.Bind<NavMeshObstacle>().FromInstance(_obstacle);

        //Container.BindInstances(_holdExecutor, _agent, _obstacle);
    }
}
