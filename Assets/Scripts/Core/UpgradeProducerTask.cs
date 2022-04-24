using Abstractions;
using UnityEngine;

namespace Core
{
    public class UpgradeProductionTask : ITask
    {
        public Sprite Icon { get; }
        public float TimeLeft { get; set; }
        public float ProductionTime { get; }
        public string TaskName { get; }
        public int Amount { get; }
        public int UnitTypeID { get; }

        public UpgradeProductionTask(float time, Sprite icon, int amount, int unitTypeID, string taskName)
        {
            Icon = icon;
            ProductionTime = time;
            TimeLeft = time;
            Amount = amount;
            UnitTypeID = unitTypeID;
            TaskName = taskName;
        }
    }
}