using System;
using Utils;

namespace Core
{
    public class StopAwaiter : BaseAwaiter<AsyncExtensions.Void>
    {
        private readonly UnitMovementStop _unitMovementStop;

        public StopAwaiter(UnitMovementStop unitMovementStop)
        {
            _unitMovementStop = unitMovementStop;
            _unitMovementStop.OnStop += ONStop;
        }

        private void ONStop()
        {
            _unitMovementStop.OnStop -= ONStop;
            _isCompleted = true;
            _continuation?.Invoke();
        }
        public override AsyncExtensions.Void GetResult() => new AsyncExtensions.Void();
    }
}