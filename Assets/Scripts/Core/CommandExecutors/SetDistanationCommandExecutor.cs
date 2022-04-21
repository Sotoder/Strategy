using Abstractions.Commands.CommandsInterfaces;
using Abstractions.Executors;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Core.CommandExecutors
{
    public class SetDistanationCommandExecutor : CommandExecutorBase<ISetDistanationCommand>
    {
        [Inject] private MainBuilding _mainBuilding;
        public override Task ExecuteSpecificCommand(ISetDistanationCommand command)
        {
            Debug.Log($"Set distanation to {command.Target}");
            _mainBuilding.UnitRallyPoint = command.Target;
            return Task.CompletedTask;
        }
    }
}