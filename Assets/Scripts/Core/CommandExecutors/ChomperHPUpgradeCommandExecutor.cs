using System.Threading;
using System.Threading.Tasks;
using Abstractions.Commands.CommandsInterfaces;
using Abstractions.Executors;
using Zenject;
using UnityEngine;
using Abstractions;

namespace Core.CommandExecutors
{
    public class ChomperHPUpgradeCommandExecutor : CommandExecutorBase<IChomperHPUpgradeCommand>
    {
        [SerializeField] private int _amountImprove;

        [Inject] private ITaskQueue _upgradeProducerQueue;

        public override Task ExecuteSpecificCommand(IChomperHPUpgradeCommand command)
        {
            if (_upgradeProducerQueue.Count() < _upgradeProducerQueue.MaximumUnitsInQueue)
            {
                _upgradeProducerQueue.Add(new UpgradeProductionTask(command.ProductionTime, command.Icon,_amountImprove, command.UnitTypeID, command.UpgradeName));
            }
            return Task.CompletedTask;
        }
    }
}