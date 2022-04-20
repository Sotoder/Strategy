using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(GameStatusModel), menuName = nameof(GameStatusModel), order = 10)]
public class GameStatusModel : ScriptableObject
{
    private Dictionary<int, List<int>> _factionsUnitsCollection = new Dictionary<int, List<int>>();
    public Dictionary<int, List<int>> FactionsUnitsCollection { get => _factionsUnitsCollection; }
}
