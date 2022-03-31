using System.Collections.Generic;
using UnityEngine;

namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IPatrolCommand : ICommand
    {
        List<Vector3> PatrolPoints { get; }
    }
}