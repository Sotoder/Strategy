using UnityEngine;
using Tools;


namespace Abstractions
{
    public interface ISelectable
    {
        float Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; }
        Outline ObjectOutline { get; }
    }
}