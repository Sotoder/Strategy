using System;
using UniRx;
using Utils;

namespace Core
{
    public class StopAwaiter : BaseAwaiter<AsyncExtensions.Void>
    {
        private readonly IDisposable _unitMovementStopSubscription;

        public StopAwaiter(UnitMovementStop unitMovementStop)
        {
            _unitMovementStopSubscription = unitMovementStop.Subscribe(ONStop);
        }

        private void ONStop(AsyncExtensions.Void v)
        {
            _unitMovementStopSubscription.Dispose();
            _isCompleted = true;
            _continuation?.Invoke();
        }
        public override AsyncExtensions.Void GetResult() => new AsyncExtensions.Void();
    }
}