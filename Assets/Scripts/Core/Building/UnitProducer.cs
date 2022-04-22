using Abstractions;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core
{
    public class UnitProducer : MonoBehaviour, IUnitProducer
    {
        public IReadOnlyReactiveCollection<IUnitProductionTask> Queue => _queue;

        public int MaximumUnitsInQueue => _maximumUnitsInQueue;

        protected ReactiveCollection<IUnitProductionTask> _queue = new ReactiveCollection<IUnitProductionTask>();

        [SerializeField] private Transform _unitsParent;
        [SerializeField] private int _maximumUnitsInQueue = 6;

        [Inject] private MainBuilding _mainBuilding;
        [Inject] private DiContainer _diContainer;
        [Inject] private FactionMember _factionMember;

        public IUnitProductionTask this[int index]
        {
            get => _queue[index];
        }

        public int Count()
        {
            return _queue.Count;
        }

        public void Add(IUnitProductionTask task)
        {
            _queue.Add(task);
        }

        protected void Update()
        {
            if (_queue.Count == 0)
            {
                return;
            }

            var innerTask = (UnitProductionTask)_queue[0];
            innerTask.TimeLeft -= Time.deltaTime;
            if (innerTask.TimeLeft <= 0)
            {
                removeTaskAtIndex(0);
                var newUnit = _diContainer.InstantiatePrefab(innerTask.UnitPrefab, new Vector3(this.transform.position.x - 3, 0, this.transform.position.z), Quaternion.identity, _unitsParent);

                newUnit.GetComponent<FactionMember>().SetFaction(_factionMember.FactionId);
                newUnit.GetComponent<MoveCommandExecuter>().ExecuteCommand(new MoveCommand(_mainBuilding.UnitRallyPoint));
            }
        }

        public void Cancel(int index) => removeTaskAtIndex(index);

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
