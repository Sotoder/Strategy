using Abstractions.Commands.CommandsInterfaces;
using System.Collections.Generic;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public sealed class PatrolCommand : IPatrolCommand
    {
        public List<Vector3> PatrolPoints { get; }

        public PatrolCommand(Vector3 target)
        {
            PatrolPoints = new List<Vector3>();

            PatrolPoints.Add(target);
        }

        public void SetStartPosition(Vector3 startPosition)
        {
            PatrolPoints.Add(startPosition);
        }
    }
}
