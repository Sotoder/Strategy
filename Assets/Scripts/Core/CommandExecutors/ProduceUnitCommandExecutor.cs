using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core.CommandExecutors
{
    public class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>, IUnitProducer
    {
        public IReadOnlyReactiveCollection<IUnitProductionTask> Queue => _queue;

        [SerializeField] private Transform _unitsParent;
        [SerializeField] private int _maximumUnitsInQueue = 6;

        [Inject] private MainBuilding _mainBuilding;
        [Inject] private DiContainer _diContainer;

        private ReactiveCollection<IUnitProductionTask> _queue = new ReactiveCollection<IUnitProductionTask>();

        private void Update()
        {
            if (_queue.Count == 0)
            {
                return;
            }

            var innerTask = (UnitProductionTask)_queue[0];
            innerTask.TimeLeft -= Time.deltaTime;
            if (innerTask.TimeLeft <= 0)
            {
                removeTaskAtIndex(0);
                var newUnit = _diContainer.InstantiatePrefab(innerTask.UnitPrefab, new Vector3(this.transform.position.x - 3, 0, this.transform.position.z), Quaternion.identity, _unitsParent);

                newUnit.GetComponent<MoveCommandExecuter>().ExecuteCommand(new MoveCommand(_mainBuilding.UnitRallyPoint));
            }
        }

        public void Cancel(int index) => removeTaskAtIndex(index);

        private void removeTaskAtIndex(int index)
        {
            for (int i = index; i < _queue.Count - 1; i++)
            {
                _queue[i] = _queue[i + 1];
            }
            _queue.RemoveAt(_queue.Count - 1);
        }

        public override Task ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            if (_queue.Count < _maximumUnitsInQueue)
            {
                _queue.Add(new UnitProductionTask(command.ProductionTime, command.Icon, command.UnitPrefab, command.UnitName));
            }
            return Task.CompletedTask;
        }
    }
}