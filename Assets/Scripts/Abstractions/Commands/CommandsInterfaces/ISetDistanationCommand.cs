using UnityEngine;

namespace Abstractions.Commands.CommandsInterfaces
{
    public interface ISetDistanationCommand : ICommand
    {
        public Vector3 Target { get; }
    }
}