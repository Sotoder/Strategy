using UnityEngine;

namespace Abstractions
{
    public interface IAttackable
    {
        Transform transform { get; }
        string name { get; }
        bool IsEnemy { get; }
    }
}
