using System;
using UniRx;
using Utils;

namespace Core
{
    public class StopAwaiter : BaseAwaiter<AsyncExtensions.Void>
    {
        public StopAwaiter(UnitMovementStop unitMovementStop)
        {
            _statelessSubscribtion = unitMovementStop.Subscribe(ONNewValue);
            _isStateless = true;
        }
        public override AsyncExtensions.Void GetResult() => new AsyncExtensions.Void();
    }
}