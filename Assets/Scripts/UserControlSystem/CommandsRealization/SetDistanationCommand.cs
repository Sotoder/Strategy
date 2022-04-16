using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public sealed class SetDistanationCommand : ISetDistanationCommand
    {
        public Vector3 Target { get; }

        public SetDistanationCommand(Vector3 target)
        {
            Target = target;
        }
    }
}