using System;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Utils;
using Zenject;

namespace Core
{
    public class UnitMovementStop : MonoBehaviour, IAwaitable<AsyncExtensions.Void>, IObservable<AsyncExtensions.Void>
    {
        private Subject<AsyncExtensions.Void> _onStop = new Subject<AsyncExtensions.Void>();

        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private NavMeshObstacle _obstacle;

        private void Update()
        {
            if (!_agent.pathPending && _agent.isActiveAndEnabled)
            {
                if (_agent.remainingDistance <= _agent.stoppingDistance)
                {
                    if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                    {
                        _onStop?.OnNext(new AsyncExtensions.Void());
                        _agent.enabled = false;
                        _obstacle.enabled = true;
                    }
                }
            }
        }

        public IAwaiter<AsyncExtensions.Void> GetAwaiter() => new StopAwaiter(this);
        public IDisposable Subscribe(IObserver<AsyncExtensions.Void> observer) => _onStop.Subscribe(observer);
    }
}