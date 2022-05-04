using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Utils;
using Zenject;

namespace UserControlSystem.CommandsRealization
{
    public class ProduceGrinaderCommand : IProduceGrinaderCommand
    {
        [Inject(Id = "Grinader")] public string UnitName { get; }
        [Inject(Id = "Grinader")] public Sprite Icon { get; }
        [Inject(Id = "Grinader")] public float ProductionTime { get; }

        public GameObject UnitPrefab => _unitPrefab;
        [InjectAsset("Grinader")] private GameObject _unitPrefab;
    }
}