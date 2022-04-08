
using System;
using UniRx;

namespace UserControlSystem
{
    public class NewValueNotifier<TAwaited> : BaseAwaiter<TAwaited>
    {
        private readonly IDisposable _statefulSubscribtion;
        private readonly IDisposable _statelessSubscribtion;

        private readonly bool _isStateless;
        private TAwaited _result;

        public NewValueNotifier(StatelessScriptableObjectValueBase<TAwaited> scriptableObjectValueBase)
        {
            _statelessSubscribtion = scriptableObjectValueBase.Subscribe(ONNewValue);
            _isStateless = true;
        }

        public NewValueNotifier(StatefulScriptableObjectValueBase<TAwaited> scriptableObjectValueBase)
        {
            _statefulSubscribtion = scriptableObjectValueBase.Subscribe(ONNewValue);
        }

        private void ONNewValue(TAwaited obj)
        {
            if (_isStateless) _statelessSubscribtion.Dispose();
            else _statefulSubscribtion.Dispose();
            _result = obj;
            _isCompleted = true;
            _continuation?.Invoke();
        }
        public override TAwaited GetResult() => _result;
    }
}