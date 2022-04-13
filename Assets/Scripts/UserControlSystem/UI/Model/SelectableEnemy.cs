using Abstractions;
using UnityEngine;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(SelectableEnemy), menuName = "Strategy Game/" + nameof(SelectableEnemy), order = 0)]
    public class SelectableEnemy : StatefulScriptableObjectValueBase<ISelectableEnemy>
    {
    }
}