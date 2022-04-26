using Abstractions;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core
{
    public class UnitProducer : MonoBehaviour, ITaskQueue
    {
        public IReadOnlyReactiveCollection<ITask> Queue => _queue;

        public int MaximumUnitsInQueue => _maximumUnitsInQueue;

        protected ReactiveCollection<ITask> _queue = new ReactiveCollection<ITask>();

        [SerializeField] private Transform _unitsParent;
        [SerializeField] private int _maximumUnitsInQueue = 6;

        [Inject] private MainBuilding _mainBuilding;
        [Inject] private DiContainer _diContainer;
        [Inject] private FactionMember _factionMember;
        [Inject] private UpgradesComposite _upgradesComposite;

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

            var innerTask = (UnitProductionTask)_queue[0];
            innerTask.TimeLeft -= Time.deltaTime;
            if (innerTask.TimeLeft <= 0)
            {
                RemoveTaskAtIndex(0);
                var newUnit = _diContainer.InstantiatePrefab(innerTask.UnitPrefab, new Vector3(this.transform.position.x - 3, 0, this.transform.position.z), Quaternion.identity, _unitsParent);

                newUnit.GetComponent<FactionMember>().SetFaction(_factionMember.FactionId);
                newUnit.GetComponent<MoveCommandExecuter>().ExecuteCommand(new MoveCommand(_mainBuilding.UnitRallyPoint));

                var upgradableUnit = newUnit.GetComponent<IUpgradableUnit>();

                if (_upgradesComposite.IsUnitHaveAnyUpgrade(upgradableUnit))
                {
                    ApplayAllUpgrades(upgradableUnit);
                }
            }
        }

        private void ApplayAllUpgrades(IUpgradableUnit upgradableUnit)
        {
            var upgradesList = _upgradesComposite.UpgradesCollection[upgradableUnit.FactionID];

            for (int i = 0; i < upgradesList.Count; i++)
            {
                if (upgradesList[i].UnitTypeID == upgradableUnit.UnitTypeID)
                {
                    upgradesList[i].ApplyUpgrade(upgradableUnit);
                }
            }
        }

        public void Cancel(int index) => RemoveTaskAtIndex(index);

        private void RemoveTaskAtIndex(int index)
        {
            for (int i = index; i < _queue.Count - 1; i++)
            {
                _queue[i] = _queue[i + 1];
            }
            _queue.RemoveAt(_queue.Count - 1);
        }
    }
}
