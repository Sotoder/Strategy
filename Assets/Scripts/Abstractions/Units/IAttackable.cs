using UnityEngine;

namespace Abstractions
{
    public interface IAttackable: ISelectable
    {
        Transform transform { get; }
        string name { get; }
    }
}
