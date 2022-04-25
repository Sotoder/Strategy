using Abstractions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = nameof(UpgradesComposite), menuName = nameof(UpgradesComposite), order = 11)]
    public class UpgradesComposite : ScriptableObject
    {
        private Dictionary<int, List<UpgradeModel>> _upgradesCollection = new Dictionary<int, List<UpgradeModel>>();

        public Dictionary<int, List<UpgradeModel>> UpgradesCollection => _upgradesCollection;
    }
}