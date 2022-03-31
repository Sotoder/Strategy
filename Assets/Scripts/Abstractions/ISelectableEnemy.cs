using UnityEngine;

namespace Abstractions
{
    public interface ISelectableEnemy
    {
        Transform transform { get; }
        string name { get; }
    }
}
