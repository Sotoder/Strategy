using Assets.Scripts.Abstractions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Core
{
    public class FactionMember : MonoBehaviour, IFactionMember
    {
        [Inject] private GameStatusModel _statusModel;
        public int FactionId => _factionId;
        [SerializeField] private int _factionId;

        private void Awake()
        {
            if (_factionId != 0)
            {
                Register();
            }
        }

        public void SetFaction(int factionID)
        {
            _factionId = factionID;
            Register();
        }

        private void OnDestroy()
        {
            Unregister();
        }
        private void Register()
        {
            lock (_statusModel.FactionsUnitsCollection)
            {
                if (!_statusModel.FactionsUnitsCollection.ContainsKey(_factionId))
                {
                    _statusModel.FactionsUnitsCollection.Add(_factionId, new List<int>());
                }
                if (!_statusModel.FactionsUnitsCollection[_factionId].Contains(GetInstanceID()))
                {
                    _statusModel.FactionsUnitsCollection[_factionId].Add(GetInstanceID());
                }
            }
        }
        private void Unregister()
        {
            lock (_statusModel.FactionsUnitsCollection)
            {
                if (_statusModel.FactionsUnitsCollection[_factionId].Contains(GetInstanceID()))
                {
                    _statusModel.FactionsUnitsCollection[_factionId].Remove(GetInstanceID());
                }
                if (_statusModel.FactionsUnitsCollection[_factionId].Count == 0)
                {
                    _statusModel.FactionsUnitsCollection.Remove(_factionId);
                }
            }
        }
    }
}