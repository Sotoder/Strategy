using Abstractions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = nameof(UpgradableUnitsComposite), menuName = nameof(UpgradableUnitsComposite), order = 11)]
    public class UpgradableUnitsComposite : ScriptableObject
    {
        private Dictionary<int, List<HPInprover>> _upgradableUnitsCollection = new Dictionary<int, List<HPInprover>>();

        public Dictionary<int, List<HPInprover>> UpgradableUnitsCollection => _upgradableUnitsCollection;
    }
}