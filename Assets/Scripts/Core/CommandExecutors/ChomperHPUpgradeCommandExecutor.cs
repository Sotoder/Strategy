using System.Threading;
using System.Threading.Tasks;
using Abstractions.Commands.CommandsInterfaces;
using Abstractions.Executors;
using Zenject;
using UnityEngine;

namespace Core.CommandExecutors
{
    public class ChomperHPUpgradeCommandExecutor : CommandExecutorBase<IChomperHPUpgradeCommand>
    {
        [SerializeField] int _amountImprove;

        [Inject] UpgradableUnitsComposit _upgradableUnitsComposit;
        [Inject] FactionMember _factionMember;

        public override Task ExecuteSpecificCommand(IChomperHPUpgradeCommand command)
        {
            if (_upgradableUnitsComposit.UpgradableUnitsCollection.ContainsKey(_factionMember.FactionId))
            {
                var ImproversList = _upgradableUnitsComposit.UpgradableUnitsCollection[_factionMember.FactionId];

                for (int i = 0; i < ImproversList.Count; i++)
                {
                    if (ImproversList[i].UnitTypeID == command.UnitTypeID)
                    {
                        ImproversList[i].ImproveCommand(_amountImprove);
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}