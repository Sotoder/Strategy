using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Zenject;

public class ProduceUnitCommandExecuter : CommandExecutorBase<IProduceUnitCommand>
{
    [SerializeField] private Transform _unitsParent;
    [Inject] private IPrefabInstantiateInstaller _prefabInstantiateInstaller;
    public override void ExecuteSpecificCommand(IProduceUnitCommand command)
    {
        _prefabInstantiateInstaller.InstantiatePrefab(command.UnitPrefab,
            new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)),
            Quaternion.identity,
            _unitsParent);
    }
}
