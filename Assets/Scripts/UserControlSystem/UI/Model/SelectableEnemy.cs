using Abstractions;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(SelectableEnemy), menuName = "Strategy Game/" + nameof(SelectableEnemy), order = 0)]
public class SelectableEnemy : BaseModel<ISelectableEnemy>
{
}
