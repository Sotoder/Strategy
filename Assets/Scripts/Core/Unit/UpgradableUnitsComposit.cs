using Abstractions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = nameof(UpgradableUnitsComposit), menuName = nameof(UpgradableUnitsComposit), order = 11)]
    public class UpgradableUnitsComposit : ScriptableObject
    {
        private Dictionary<int, List<HPInprover>> _upgradableUnitsCollection = new Dictionary<int, List<HPInprover>>();

        public Dictionary<int, List<HPInprover>> UpgradableUnitsCollection => _upgradableUnitsCollection;
    }
}