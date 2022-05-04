using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;
using Utils;
using Zenject;

namespace UserControlSystem
{
    public sealed class ProduceGrinaderCommandCommandCreator : CommandCreatorBase<IProduceGrinaderCommand>
    {
        [Inject] private AssetsContext _context;
        [Inject] private DiContainer _diContainer;

        protected override void ClassSpecificCommandCreation(Action<IProduceGrinaderCommand> creationCallback)
        {
            var produceUnitCommand = _context.Inject(new ProduceGrinaderCommand());
            _diContainer.Inject(produceUnitCommand);
            creationCallback?.Invoke(produceUnitCommand);
        }
    }
}