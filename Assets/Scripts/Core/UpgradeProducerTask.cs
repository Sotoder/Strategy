using Abstractions;
using System;
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
        public MainUnit UnitPref { get; }
        public Action ReduceUpgradesCountAction { get; }

        public UpgradeProductionTask(float time, Sprite icon, int amount, int unitTypeID, string taskName, MainUnit unitPref, Action reduceUpgradesCountAction)
        {
            Icon = icon;
            ProductionTime = time;
            TimeLeft = time;
            Amount = amount;
            UnitTypeID = unitTypeID;
            TaskName = taskName;
            UnitPref = unitPref;
            ReduceUpgradesCountAction = reduceUpgradesCountAction;
        }
    }
}