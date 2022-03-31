using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

public class ProduceUnitCommandExecuter : CommandExecutorBase<IProduceUnitCommand>
{
    [SerializeField] private Transform _unitsParent;
    public override void ExecuteSpecificCommand(IProduceUnitCommand command)
    {
        var unit = Instantiate(command.UnitPrefab,
            new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)),
            Quaternion.identity,
            _unitsParent);
        unit.GetComponent<BaseUnit>().IsEnemy = false;
    }
}
