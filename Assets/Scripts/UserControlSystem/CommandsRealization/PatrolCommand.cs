using Abstractions.Commands.CommandsInterfaces;
using System.Collections.Generic;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public sealed class PatrolCommand : IPatrolCommand
    {
        public List<Vector3> PatrolPoints { get; }

        public PatrolCommand(Vector3 start, Vector3 end)
        {
            PatrolPoints = new List<Vector3>();

            PatrolPoints.Add(start);
            PatrolPoints.Add(end);
        }
    }
}
