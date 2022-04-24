using System.Threading.Tasks;
using Abstractions.Commands.CommandsInterfaces;
using Abstractions.Executors;
using Zenject;
using UnityEngine;
using Abstractions;
using Abstractions.Commands;

namespace Core.CommandExecutors
{
    public abstract class UpgradeHPCommandExecutor<T> : CommandExecutorBase<T> where T : class, IUnitUpgradeCommand
    {
        [SerializeField] protected int _amountImprove;

        [Inject] protected ITaskQueue _upgradeProducerQueue;

        public override Task ExecuteSpecificCommand(T command)
        {
            if (_upgradeProducerQueue.Count() < _upgradeProducerQueue.MaximumUnitsInQueue)
            {
                _upgradeProducerQueue.Add(new UpgradeProductionTask(command.ProductionTime, command.Icon, _amountImprove, command.UnitTypeID, command.UpgradeName));
            }
            return Task.CompletedTask;
        }
    }
}