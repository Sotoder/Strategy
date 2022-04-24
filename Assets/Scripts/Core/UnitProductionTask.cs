using Abstractions;
using UnityEngine;

namespace Core
{
    public class UnitProductionTask : ITask
    {
        public Sprite Icon { get; }
        public float TimeLeft { get; set; }
        public float ProductionTime { get; }
        public string TaskName { get; }
        public GameObject UnitPrefab { get; }

        public UnitProductionTask(float time, Sprite icon, GameObject unitPrefab, string unitName)
        {
            Icon = icon;
            ProductionTime = time;
            TimeLeft = time;
            UnitPrefab = unitPrefab;
            TaskName = unitName;
        }
    }
}