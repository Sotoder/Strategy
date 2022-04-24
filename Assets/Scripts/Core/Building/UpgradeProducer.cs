using Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core
{
    public class UpgradeProducer : MonoBehaviour, ITaskQueue
    {
        public IReadOnlyReactiveCollection<ITask> Queue => _queue;

        public int MaximumUnitsInQueue => _maximumUnitsInQueue;

        private ReactiveCollection<ITask> _queue = new ReactiveCollection<ITask>();
        private Action _reduceUpgradesCountAction; 

        [SerializeField] private int _maximumUnitsInQueue = 5;

        [Inject] UpgradableUnitsComposit _upgradableUnitsComposit;
        [Inject] FactionMember _factionMember;

        public ITask this[int index]
        {
            get => _queue[index];
        }

        public int Count()
        {
            return _queue.Count;
        }

        public void Add(ITask task)
        {
            _queue.Add(task);
        }

        protected void Update()
        {
            if (_queue.Count == 0)
            {
                return;
            }

            var innerTask = (UpgradeProductionTask)_queue[0];
            _reduceUpgradesCountAction = innerTask.ReduceUpgradesCountAction;

            innerTask.TimeLeft -= Time.deltaTime;
            if (innerTask.TimeLeft <= 0)
            {
                removeTaskAtIndex(0);

                if (_upgradableUnitsComposit.UpgradableUnitsCollection.ContainsKey(_factionMember.FactionId))
                {
                    var ImproversList = _upgradableUnitsComposit.UpgradableUnitsCollection[_factionMember.FactionId];

                    for (int i = 0; i < ImproversList.Count; i++)
                    {
                        if (ImproversList[i].UnitTypeID == innerTask.UnitTypeID)
                        {
                            ImproversList[i].ImproveCommand(innerTask.Amount);
                        }
                    }
                }

                innerTask.UnitPref.UpgradeHealth(innerTask.Amount);
            }
        }


        public void Cancel(int index)
        {
            _reduceUpgradesCountAction.Invoke();
            removeTaskAtIndex(index);
        }

        private void removeTaskAtIndex(int index)
        {
            for (int i = index; i < _queue.Count - 1; i++)
            {
                _queue[i] = _queue[i + 1];
            }
            _queue.RemoveAt(_queue.Count - 1);
        }
    }
}