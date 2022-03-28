using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Utils;

public class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>
{
    [InjectAsset("UnitsRoot")] private GameObject _unitsParent;
    public override void ExecuteSpecificCommand(IProduceUnitCommand command)
        => GameObject.Instantiate(command.UnitPrefab,
            new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)),
            Quaternion.identity,
            _unitsParent.transform);
}
