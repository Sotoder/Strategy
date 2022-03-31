using Abstractions;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public class AttackCommand : IAttackCommand
    {
        public Vector3 Target { get; }
        public IAttackable Enemy { get; }

        public AttackCommand(Vector3 target)
        {
            Target = target;
        }

        public AttackCommand(IAttackable enemy)
        {
            Enemy = enemy;
        }
    }
}
