using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core
{
    public class GameStatus : MonoBehaviour, IGameStatus
    {
        [Inject] private GameStatusModel model;

        private int GetFactionsCount()
        {
            lock (model.FactionsUnitsCollection)
            {
                return model.FactionsUnitsCollection.Count;
            }
        }
        private int GetWinner()
        {
            lock (model.FactionsUnitsCollection)
            {
                return model.FactionsUnitsCollection.Keys.First();
            }
        }

        public IObservable<int> Status => _status;

        private Subject<int> _status = new Subject<int>();
        private void ÑheckStatus(object state)
        {
            if (GetFactionsCount() == 0)
            {
                _status.OnNext(0);
            }
            else if (GetFactionsCount() == 1)
            {
                _status.OnNext(GetWinner());
            }
        }
        private void Update()
        {
            ThreadPool.QueueUserWorkItem(ÑheckStatus);
        }
    }
}