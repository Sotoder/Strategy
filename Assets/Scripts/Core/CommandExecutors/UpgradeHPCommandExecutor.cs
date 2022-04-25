using System.Threading.Tasks;
using Abstractions.Commands.CommandsInterfaces;
using Abstractions.Executors;
using Zenject;
using UnityEngine;
using Abstractions;

namespace Core.CommandExecutors
{
    public abstract class UpgradeHPCommandExecutor<T> : CommandExecutorBase<T> where T : class, IUnitUpgradeCommand
    {
        [SerializeField] protected int _amountImprove;
        [SerializeField] private int _maxUpgradesCount;
        [SerializeField] private int _upgradeID;

        private int _upgradesCount;

        [Inject] protected ITaskQueue _upgradeProducerQueue;

        public override Task ExecuteSpecificCommand(T command)
        {
            if (_upgradesCount == _maxUpgradesCount) return Task.CompletedTask; ;

            if (_upgradeProducerQueue.Count() < _upgradeProducerQueue.MaximumUnitsInQueue)
            {
                _upgradeProducerQueue.Add(new UpgradeProductionTask(command.ProductionTime, command.Icon, _amountImprove, 
                    command.UnitTypeID, command.UpgradeName, _upgradeID, ReduceUpgradesCount));
                _upgradesCount++;
            }
            return Task.CompletedTask;
        }

        public void ReduceUpgradesCount()
        {
            _upgradesCount--;
        }
    }
}