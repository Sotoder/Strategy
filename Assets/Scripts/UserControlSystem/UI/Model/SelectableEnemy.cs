using Abstractions;
using UnityEngine;
using Utils;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(SelectableEnemy), menuName = "Strategy Game/" + nameof(SelectableEnemy), order = 0)]
    public class SelectableEnemy : StatefulScriptableObjectValueBase<ISelectableEnemy>
    {
    }
}