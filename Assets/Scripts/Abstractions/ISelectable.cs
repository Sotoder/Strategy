using Abstractions.Commands;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Abstractions
{
    public interface ISelectable
    {
        float Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; }
        Outline ObjectOutline { get; }
        List<ICommandExecutor> CommandExecutorsList { get; }
    }
}