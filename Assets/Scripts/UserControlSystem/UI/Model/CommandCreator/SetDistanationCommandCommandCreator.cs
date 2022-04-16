using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandsRealization;

namespace UserControlSystem
{
    public sealed class SetDistanationCommandCommandCreator : CancellableCommandCreatorBase<ISetDistanationCommand, Vector3>
    {
        protected override ISetDistanationCommand CreateCommand(Vector3 argument) => new SetDistanationCommand(argument);
    }
}