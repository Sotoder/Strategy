using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using Abstractions.Executors;
using System.Threading.Tasks;
using Zenject;

namespace Core.CommandExecutors
{
    public abstract class ProduceUnitCommandExecutor<T> : CommandExecutorBase<T> where T: class, IProduceUnitCommand
    {
        [Inject] protected ITaskQueue _unitProducerQueue;
        public override Task ExecuteSpecificCommand(T command)
        {
            if (_unitProducerQueue.Count() < _unitProducerQueue.MaximumUnitsInQueue)
            {
                _unitProducerQueue.Add(new UnitProductionTask(command.ProductionTime, command.Icon, command.UnitPrefab, command.UnitName));
            }
            return Task.CompletedTask;
        }
    }
}